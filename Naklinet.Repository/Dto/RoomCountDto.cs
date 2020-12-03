using Naklinet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naklinet.Repository.Dto
{
    public class RoomCountDto
    {
        public int ID { get; set; }
        public string Count { get; set; }
        public double BasePrice { get; set; }
        public int I { get; set; }


        public virtual ICollection<ToAddresses> ToAddresses { get; set; }
        public virtual ICollection<FromAddresses> FromAddresses { get; set; }

    }
}
