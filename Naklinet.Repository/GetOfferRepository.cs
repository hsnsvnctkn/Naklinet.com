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

        public GetOfferDto GetOfferDto()
        {
            var roomCount = _context.RoomCounts.Select(r => new RoomCountDto
            {
                BasePrice = r.BasePrice,
                Count = r.Count,
                ID = r.ID
            }).ToList();

            var packagingOptions = _context.PackagingOptions.Select(po => new PackagingOptions
            {
                ID = po.ID,
                OptionFactor = po.OptionFactor,
                OptionName = po.OptionName
            }).ToList();

            return new GetOfferDto { roomCounts = roomCount, PackagingOptions = packagingOptions };
        }
    }
}
