using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naklinet.Domain.Entities
{
    [Table("STEPEXPLANATION")]
    public class StepExplanation
    {
        [Key]
        public int ID { get; set; }
        public int StepI { get; set; }
        public string Explanation { get; set; }
    }
}
