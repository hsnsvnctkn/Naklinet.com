using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("VEHICLES")]
    public class Vehicles
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(10)]
        public string LicensePlate { get; set; }
        public int TypeID { get; set; } //FK
        public int ShipperID { get; set; } //FK
        public int Height { get; set; }
        public int Weight { get; set; }


        public virtual VehicleTypes VehicleType { get; set; }
        public virtual Shippers Shipper { get; set; }
    }
}
