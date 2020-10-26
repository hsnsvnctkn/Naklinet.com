using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("VEHICLETYPES")]
    public class VehicleTypes
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(50)]
        public string TypeName { get; set; }


        public virtual ICollection<Vehicles> Vehicles { get; set; }
    }
}
