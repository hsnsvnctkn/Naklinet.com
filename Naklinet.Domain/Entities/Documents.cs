using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("DOCUMENTS")]
    public class Documents
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int TypeID { get; set; }
        public int ShipperID { get; set; }


        public virtual DocumentTypes DocumentType { get; set; }
        public virtual Shippers Shipper { get; set; }
    }
}
