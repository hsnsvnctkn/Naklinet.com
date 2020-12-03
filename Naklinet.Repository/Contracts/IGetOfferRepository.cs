using Naklinet.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naklinet.Repository.Contracts
{
    public interface IGetOfferRepository : IGenericRepository<GetOfferDto>
    {
        GetOfferDto GetOfferDto();
        double? GetPrice(TransportInfo info);
        CustomerDto FindCustomer(string customerNo);
        void CreateCustomerWithNo(string customerNo);
        bool IsThereCustomer(string customerNo);
        void UpdateLeftStep(int step, string phone);
        int CreateOffer(TransportInfo transportInfo, double? price);
        void CreateReservation(TransportInfo transportInfo);
    }
}
