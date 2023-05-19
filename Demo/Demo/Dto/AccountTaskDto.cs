using Demo.Models;
using System;
using System.Collections.Generic;

namespace Demo.Dto
{
    public class AccountTaskDto
    {
        public int AccountId { get; set; }

        public string NameEmp { get; set; }

        public string BranchName { get; set; }

        public string ProductName { get; set; }

        public string? ProductTypeCd { get; set; }

        public float? AvailBalance { get; set; }

        public DateTime? CloseDate { get; set; }

        public DateTime? LastActivityDate { get; set; }

        public DateTime OpenDate { get; set; }

        public float? PendingBalance { get; set; }

        public string? Status { get; set; }

        public List<AccTransactionTaskDto> AccTransactionList { get; set; }

        public AccountTaskDto() 
        {
            AccTransactionList = new List<AccTransactionTaskDto>();
        }
    }
}
