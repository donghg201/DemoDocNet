using System;

namespace Demo.Dto
{
    public class AccTransactionGetDto
    {
        public int TxnId { get; set; }

        public float Amount { get; set; }

        public DateTime FundsAvailDate { get; set; }

        public DateTime TxnDate { get; set; }

        public string? TxnTypeCd { get; set; }

        //public Account Account { get; set; }

        public BranchDto Branch { get; set; }

        public EmployeeGetDto Employee { get; set; }
    }
}
