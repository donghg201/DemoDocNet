﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class AccTransaction
    {
        [Key]
        [Required]
        public int TxnId { get; set; }

        [Required]
        public float Amount { get; set; }

        [Required]
        public DateTime FundsAvailDate { get; set; }

        [Required]
        public DateTime TxnDate { get; set; }

        [StringLength(10)]
        public string? TxnTypeCd { get; set; }

        public int? AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        public int? ExecutionBranchId { get; set; }
        [ForeignKey("ExecutionBranchId")]
        public Branch Branch { get; set; }

        public int? TellerEmpId { get; set; }
        [ForeignKey("TellerEmpId")]
        public Employee Employee { get; set; }

    }
}
