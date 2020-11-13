using Naklinet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naklinet.Repository.Dto
{
    public class GetOfferDto
    {
        public List<RoomCountDto> roomCounts { get; set; }
        public List<PackagingOptions> PackagingOptions { get; set; }
    }
}
