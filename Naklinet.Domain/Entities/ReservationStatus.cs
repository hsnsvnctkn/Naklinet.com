using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("RESERVATIONSTATUS")]
    public class ReservationStatus
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string StatusName { get; set; }


        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
