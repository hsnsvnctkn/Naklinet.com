using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("EMPLOYEES")]
    public class Employees
    {
        [Key]
        public int ID { get; set; }
        [Required,StringLength(30)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Surname { get; set; }
        [Required, StringLength(14)]
        public string Phone { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; } //FK
        public int ShipperID { get; set; } //FK


        public virtual Roles Role { get; set; }
        public virtual Shippers Shipper { get; set; }
        public virtual ICollection<Reservations> ReservationDriver { get; set; }
    }
}
