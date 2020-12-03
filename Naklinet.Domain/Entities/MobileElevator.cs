using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("MOBILEELEVATOR")]
    public class MobileElevator
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string OpitonText { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
