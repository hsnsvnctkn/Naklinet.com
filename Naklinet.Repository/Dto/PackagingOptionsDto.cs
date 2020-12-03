using System;
using System.Collections.Generic;
using System.Text;

namespace Naklinet.Repository.Dto
{
    public class PackagingOptionsDto
    {
        public int ID { get; set; }
        public string OptionName { get; set; }
        public double OptionFactor { get; set; }
    }
}
