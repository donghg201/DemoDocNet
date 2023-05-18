using Demo.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Dto
{
    public class CustomerAccountDto
    {
        public int AccountId { get; set; }
        public string? Address { get; set; }

        public string? City { get; set; }

        public string CustTypeCd { get; set; }

        public string FedId { get; set; }

        public string? PostalCode { get; set; }

        public string? State { get; set; }

        public float? AvailBalance { get; set; }

        public DateTime? CloseDate { get; set; }

        public DateTime? LastActivityDate { get; set; }

        public DateTime OpenDate { get; set; }

        public float? PendingBalance { get; set; }

        public string? Status { get; set; }

        public int? CustId { get; set; }

        public int OpenBranchId { get; set; }

        public int OpenEmpId { get; set; }

        public string ProductCd { get; set; }

        public int TxnId { get; set; }

        public float Amount { get; set; }

        public DateTime FundsAvailDate { get; set; }

        public DateTime TxnDate { get; set; }

        public string? TxnTypeCd { get; set; }

        public int? ExecutionBranchId { get; set; }

        public int? TellerEmpId { get; set; }
    }
}
