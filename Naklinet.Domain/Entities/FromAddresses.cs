using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("FROMADDRESSES")]
    public class FromAddresses
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public bool Elevator { get; set; }
        [Required,StringLength(20)]
        public string City { get; set; }
        [Required,StringLength(30)]
        public string District { get; set; }
        [Required]
        public string State { get; set; }
        [Required, MaxLength(20)]
        public int Floor { get; set; }
        public int RoomCountID { get; set; }
        public int ReservationID { get; set; }


        public virtual RoomCount RoomCount { get; set; }
        public virtual Reservations Reservation { get; set; }
    }
}
