using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("POINTS")]
    public class Points
    {
        [Key]
        public int ID { get; set; }
        public int ShipperID { get; set; }
        [Required,MinLength(0),MaxLength(10)]
        public int Time { get; set; }
        [Required, MinLength(0), MaxLength(10)]
        public int Contentment { get; set; }
        [Required, MinLength(0), MaxLength(10)]
        public int Cominication { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public int ReservationID { get; set; }
        public DateTime PointDate { get; set; } = DateTime.Now;

        public virtual Shippers Shipper { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Reservations Reservation { get; set; }

    }
}
