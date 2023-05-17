using Demo.Models;
using System;

namespace Demo.Dto
{
    public class CustomerBussinessDto
    {
        public int CustId { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string CustTypeCd { get; set; }
        public string Name { get; set; }
        public DateTime? IncorpDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
