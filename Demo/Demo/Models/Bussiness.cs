using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Bussiness
    {
        [StringLength(10)]
        [Required]
        [Key]
        public string StateId { get; set; }

        public DateTime? IncorpDate { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Range(0, 10)]
        [Required]
        public int CustId { get; set; }
        [ForeignKey("CustId")]
        public Customer Customer { get; set; }
    }
}
