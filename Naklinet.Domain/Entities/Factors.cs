using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("FACTORS")]
    public class Factors
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public double RoomCountFactor { get; set; }
        [Required]
        public double FloorFactor { get; set; }
        [Required]
        public double MontageFactor { get; set; }
        [Required]
        public double WayDiff { get; set; }
    }
}
