using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("OFFERS")]
    public class Offers
    {
        public int ID { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public int? FromRoomCountID { get; set; }
        public bool FromElevator { get; set; }
        public int? FromFloor { get; set; }
        public bool ToElevator { get; set; }
        public int? ToFloor { get; set; }
        public int MobileElevatorID { get; set; }
        public int PackagingOptionID { get; set; }
        public bool Montage { get; set; }
        public bool IsCompleted { get; set; }
        public double OfferPrice { get; set; }

        public DateTime? TransportDate { get; set; }

        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
    }
}
