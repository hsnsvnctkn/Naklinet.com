using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("Roles")]
    public class Roles
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(30)]
        public string Name { get; set; }


        public virtual ICollection<Employees> Employees { get; set; }
    }
}
