using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("DOCUMENTTYPES")]
    public class DocumentTypes
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string TypeName { get; set; }


        public virtual ICollection<Documents> Documents { get; set; }
    }
}
