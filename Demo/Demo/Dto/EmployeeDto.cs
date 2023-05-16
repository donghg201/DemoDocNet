using Demo.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Demo.Dto
{
    public class EmployeeDto
    {
        public DateTime? EndDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime StartDate { get; set; }

        public string? Title { get; set; }

        public int? AssignedBranchId { get; set; }

        public int? DeptId { get; set; }

        public int? SuperiorEmpId { get; set; }
    }
}
