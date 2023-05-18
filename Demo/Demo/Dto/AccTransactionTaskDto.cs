using System;

namespace Demo.Dto
{
    public class AccTransactionTaskDto
    {
        public int TxnId { get; set; }

        public string NameEmp { get; set; }

        public string BranchName { get; set; }

        public float Amount { get; set; }

        public DateTime FundsAvailDate { get; set; }

        public DateTime TxnDate { get; set; }

        public string? TxnTypeCd { get; set; }

    }
}
