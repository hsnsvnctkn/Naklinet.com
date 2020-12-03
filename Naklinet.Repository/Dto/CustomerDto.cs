using System;
using System.Collections.Generic;
using System.Text;

namespace Naklinet.Repository.Dto
{
    public class CustomerDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? LeftStep { get; set; }
    }
}
