using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("RESERVATIONS")]
    public class Reservations
    {
        [Key]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int ShipperID { get; set; }
        public double PriceToCustomer { get; set; }
        public double PriceToShipper { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? TransportDate { get; set; }
        public bool Montage { get; set; }
        public int PackagingOptionID { get; set; }
        public int DriverID { get; set; }
        public int StatusID { get; set; }
        public bool IsAccepted { get; set; }



        public virtual Customer Customer { get; set; }
        public virtual Shippers Shipper { get; set; }
        public virtual PackagingOptions PackagingOption { get; set; }
        public virtual Employees Driver { get; set; }
        public virtual ReservationStatus ReservationStatus { get; set; }
        public virtual ToAddresses ToAddress { get; set; }
        public virtual FromAddresses FromAddress { get; set; }
        public virtual Points Point { get; set; }
        public virtual Comments Comment { get; set; }
    }
}
