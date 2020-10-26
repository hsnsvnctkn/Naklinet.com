using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("PACKAGINGOPTIONS")]
    public class PackagingOptions
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string OptionName { get; set; }
        public double OptionFactor { get; set; }


        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
