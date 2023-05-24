using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int CustId { get; set; }

        [StringLength(30)]
        public string? Address { get; set; }

        [StringLength(20)]
        public string? City { get; set; }

        [Required]
        [StringLength(1)]
        public string CustTypeCd { get; set; }

        [Required]
        [StringLength(12)]
        public string FedId { get; set; }

        [StringLength(10)]
        public string? PostalCode { get; set; }

        [StringLength(20)]
        public string? State { get; set; }

        public List<Account> Accounts { get; set; }
        public List<Bussiness> Bussiness { get; set; }
        public List<Individual> Individuals { get; set; }
    }
}
