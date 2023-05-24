using System.Collections.Generic;

namespace Demo.Dto
{
    public class CustomerTaskDto
    {
        public int CustId { get; set; }

        public float? SumAvail { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string CustTypeCd { get; set; }

        public string FedId { get; set; }

        public string? PostalCode { get; set; }

        public string? State { get; set; }

        public List<AccountTaskDto> AccountList { get; set; }

        public CustomerTaskDto() 
        {
            AccountList = new List<AccountTaskDto>();
        }
    }
}
