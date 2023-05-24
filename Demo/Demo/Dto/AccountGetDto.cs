using System;

namespace Demo.Dto
{
    public class AccountGetDto
    {
        public int AccountId { get; set; }
        public float? AvailBalance { get; set; }

        public DateTime? CloseDate { get; set; }

        public DateTime? LastActivityDate { get; set; }

        public DateTime OpenDate { get; set; }

        public float? PendingBalance { get; set; }

        public string? Status { get; set; }

        //public int? CustId { get; set; }

        //public int OpenBranchId { get; set; }

        //public int OpenEmpId { get; set; }

        //public string ProductCd { get; set; }

        public ProductDto Product { get; set; }

        public EmployeeGetDto Employee { get; set; }

        public BranchDto Branch { get; set; }

        public CustomerGetDto Customer { get; set; }
    }
}
