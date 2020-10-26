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

            return new GetOfferDto { roomCounts = roomCount };
        }
    }
}
