using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Individual
    {
        public DateTime? BirthDate { get; set; }

        [StringLength(30)]
        [Required]
        [Key]
        public string FirstName { get; set; }

        [StringLength(30)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public int CustId { get; set; }
        [ForeignKey("CustId")]
        public Customer Customer { get; set; }
    }
}
