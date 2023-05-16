using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Dto
{
    public class CustomerDto
    {
        public string? Address { get; set; }

        public string? City { get; set; }

        public string CustTypeCd { get; set; }

        public string FedId { get; set; }

        public string? PostalCode { get; set; }

        public string? State { get; set; }

        public string StateId { get; set; }

        public DateTime? IncorpDate { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
