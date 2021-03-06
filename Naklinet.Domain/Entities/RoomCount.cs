﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("ROOMCOUNT")]
    public class RoomCount
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Count { get; set; }
        [Required]
        public int I { get; set; }


        public virtual ICollection<ToAddresses> ToAddresses { get; set; }
        public virtual ICollection<FromAddresses> FromAddresses { get; set; }
    }
}
