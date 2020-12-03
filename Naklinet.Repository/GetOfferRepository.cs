using Naklinet.Domain.Entities;
using Naklinet.Repository.Contracts;
using Naklinet.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Naklinet.Repository
{
    public class GetOfferRepository : GenericRepository<GetOfferDto>, IGetOfferRepository
    {
        public GetOfferRepository(IUnitOfWork uow) : base(uow)
        {

        }

        //Sayfa Bilgileri çek
        public GetOfferDto GetOfferDto()
        {
            var roomCount = _context.RoomCounts.Select(r => new RoomCountDto
            {
                Count = r.Count,
                ID = r.ID,
                I = r.I,
            }).OrderBy(rc => rc.I).ToList();

            var packagingOptions = _context.PackagingOptions.Select(po => new PackagingOptions
            {
                ID = po.ID,
                OptionFactor = po.OptionFactor,
                OptionName = po.OptionName
            }).ToList();

            var mobileElevator = _context.MobileElevator.Select(me => new MobileElevatorDto
            {
                ID = me.ID,
                OpitonText = me.OpitonText,
                Price = me.Price
            }).ToList();

            var stepExp = _context.StepExplanations.OrderBy(se => se.StepI).ToList();

            return new GetOfferDto { roomCounts = roomCount, PackagingOptions = packagingOptions, mobileElevator = mobileElevator, StepExplanations = stepExp };
        }

        //Teklif fiyatı al
        public double? GetPrice(TransportInfo info)
        {
            var km = 10;
            var roomCount = _context.RoomCounts.Where(rc => rc.ID == info.FromRoomCountID).FirstOrDefault();
            var factors = _context.Factors.FirstOrDefault();
            var mobileElevator = _context.MobileElevator.Where(me => me.ID == info.MobileElevatorID).FirstOrDefault();
            var packagingOption = _context.PackagingOptions.Where(po => po.ID == info.PackagingOptionID).FirstOrDefault();

            //Oda sayısı başlangıç fiyatı
            double? price = (roomCount.I * factors.RoomCountFactor);

            //Yol uzunluğu
            price += (km * factors.WayFactor);

            //Eski ev asansör
            if (info.FromElevator)
                price += (info.FromFloor * factors.FloorFactor) / 2;
            else
                price += (info.FromFloor * factors.FloorFactor);

            //Yeni ev asansör
            if (info.ToElevator)
                price += (info.ToFloor * factors.FloorFactor) / 2;
            else
                price += (info.ToFloor * factors.FloorFactor);

            //Mobil asansör
            if (mobileElevator.Text == "from" || mobileElevator.Text == "to")
            {
                if (roomCount.I > 3)
                    price += (factors.MobileElevatorFactor * (factors.MobileElevatorIncrease * (roomCount.I - 3)));
                else
                    price += (factors.MobileElevatorFactor);
            }
            else if (mobileElevator.Text == "both")
            {
                if (roomCount.I > 3)
                    price += ((factors.MobileElevatorFactor * 2) * (factors.MobileElevatorIncrease * (roomCount.I - 3)));
                else
                    price += (factors.MobileElevatorFactor * 2);
            }

            //Paketleme
            price += (packagingOption.OptionFactor * (roomCount.I * factors.RoomCountFactor));

            //Montaj
            if (info.Montage)
                price += factors.MontageFactor * roomCount.I;


            return price;
        }

        //Teklif oluştur
        public int CreateOffer(TransportInfo transportInfo, double? price)
        {
            var offer = new Offers
            {
                CustomerPhone = transportInfo.CustomerPhone,
                FromAddress = transportInfo.FromAddress,
                FromElevator = transportInfo.FromElevator,
                IsCompleted = false,
                MobileElevatorID = transportInfo.MobileElevatorID,
                Montage = transportInfo.Montage,
                PackagingOptionID = transportInfo.PackagingOptionID,
                ToAddress = transportInfo.ToAddress,
                ToElevator = transportInfo.ToElevator,
            };

            if (transportInfo.FromFloor != null)
                offer.FromFloor = transportInfo.FromFloor;
            if (transportInfo.ToFloor != null)
                offer.ToFloor = transportInfo.ToFloor;
            if (transportInfo.FromRoomCountID != null)
                offer.FromRoomCountID = transportInfo.FromRoomCountID;
            if (price != null)
                offer.OfferPrice = (double)price;

            _context.Offers.Add(offer);
            _context.SaveChanges();

            return offer.ID;
        }

        //Bu numarada müşteri var mı ?
        public bool IsThereCustomer(string customerNo)
        {
            if (_context.Customers.Where(c => c.Phone == customerNo).FirstOrDefault() != null)
                return true;
            else
                return false;
        }

        //Numara ile müşteri bilgileri çek
        public CustomerDto FindCustomer(string customerNo)
        {
            return _context.Customers.Where(c => c.Phone == customerNo).Select(c => new CustomerDto
            {
                ID = c.ID,
                Phone = c.Phone,
                Email = c.Email,
                LeftStep = c.LeftStep,
                Name = c.Name,
                Surname = c.Surname
            }).FirstOrDefault();
        }

        //Numara ile müşteri oluştur.
        public void CreateCustomerWithNo(string customerNo)
        {
            _context.Customers.Add(new Customer
            {
                Phone = customerNo
            });
            _context.SaveChanges();
        }

        //Her adımda adım bilgisini güncelle
        public void UpdateLeftStep(int step, string phone)
        {
            var customer = _context.Customers.Where(c => c.Phone == phone).FirstOrDefault();
            customer.LeftStep = step;

            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        //Rezervasyon oluştur
        public void CreateReservation(TransportInfo transportInfo)
        {

        }
    }
}
