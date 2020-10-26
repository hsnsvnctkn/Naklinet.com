using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("CUSTOMER")]
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(30)]
        public string Name { get; set; }
        [Required, StringLength(40)]
        public string Surname { get; set; }
        [Required, StringLength(14)]
        public string Phone { get; set; }
        public string Email { get; set; }


        public virtual ICollection<Reservations> Reservations { get; set; } //1 müşterinin birden fazla rezervasyonu olabilir mi ??
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Points> Points { get; set; }
    }
}
