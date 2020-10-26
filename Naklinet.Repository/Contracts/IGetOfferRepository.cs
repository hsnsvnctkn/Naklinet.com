using Naklinet.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naklinet.Repository.Contracts
{
    public interface IGetOfferRepository : IGenericRepository<GetOfferDto>
    {
        GetOfferDto GetOfferDto();
    }
}
