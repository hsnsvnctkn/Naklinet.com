using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("COMMENTS")]
    public class Comments
    {
        [Key]
        public int ID { get; set; }
        public int ShipperID { get; set; }
        public int CustomerID { get; set; }
        public int ReservationID { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.Now;
        [Required]
        public bool Check { get; set; }
        [Required,StringLength(150)]
        public string Comment { get; set; }


        public virtual Shippers Shipper { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Reservations Reservation { get; set; }
    }
}
