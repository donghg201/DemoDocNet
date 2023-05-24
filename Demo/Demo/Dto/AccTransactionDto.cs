using System;

namespace Demo.Dto
{
    public class AccTransactionDto
    {

        public float Amount { get; set; }

        public DateTime FundsAvailDate { get; set; }

        public DateTime TxnDate { get; set; }

        public string? TxnTypeCd { get; set; }

        public int? AccountId { get; set; }

        public int? ExecutionBranchId { get; set; }

        public int? TellerEmpId { get; set; }
    }
}
