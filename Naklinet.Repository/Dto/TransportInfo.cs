﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Naklinet.Repository.Dto
{
    public class TransportInfo
    {
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
        public int? OfferID { get; set; }

        public DateTime TransportDate { get; set; }

        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
    }
}
