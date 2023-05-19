using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Account
    {
        [Key]
        [Required]
        public int AccountId { get; set; }

        public float? AvailBalance { get; set; }

        public DateTime? CloseDate { get; set; }

        public DateTime? LastActivityDate { get; set; }

        [Required]
        public DateTime OpenDate { get; set; }

        public float? PendingBalance { get; set; }

        [StringLength(30)]
        public string? Status { get; set; }

        public int? CustId { get; set; }
        [ForeignKey("CustId")]
        public Customer Customer { get; set; }

        [Required]
        public int OpenBranchId { get; set;}
        [ForeignKey("OpenBranchId")]
        public Branch Branch { get; set; }

        [Required]
        public int OpenEmpId { get; set;}
        [ForeignKey("OpenEmpId")]
        public Employee Employee { get; set; }

        [StringLength(10)]
        [Required]
        public string ProductCd { get; set;}
        [ForeignKey("ProductCd")]
        public Product Product { get; set; }

        public List<AccTransaction> AccTransaction { get; set; }    
    }
}
