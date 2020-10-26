using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("SHIPPERS")]
    public class Shippers
    {
        [Key, Display(Name = "#")]
        public int ID { get; set; }
        [Required, StringLength(50), Display(Name = "Firma Adı")]
        public string Name { get; set; }
        [Required, Display(Name = "Durum")]
        public bool Status { get; set; }
        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Display(Name = "Vergi No")]
        public string TaxNumber { get; set; }
        [Display(Name = "Vergi Daire")]
        public string TaxAuthority { get; set; }
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Required, StringLength(14), Display(Name = "Telefon No")]
        public string Phone { get; set; }
        [Required, Display(Name = "Firma Kuruluş Tarihi")]
        public DateTime FoundingDate { get; set; }
        [StringLength(14), Display(Name = "Fax No")]
        public string Fax { get; set; }


        public virtual ICollection<Vehicles> Vehicles { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<Reservations> Reservations { get; set; }
        public virtual ICollection<Points> Points { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Documents> Documents { get; set; }
    }
}
