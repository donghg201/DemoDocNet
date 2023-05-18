using Demo.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Dto
{
    public class BranchDto
    {
        public int BranchId { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

    }
}
