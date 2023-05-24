﻿using System;

namespace Demo.Dto
{
    public class EmployeeDto
    {
        public int EmpId { get; set; }
        public DateTime? EndDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime StartDate { get; set; }

        public string? Title { get; set; }

        public int? AssignedBranchId { get; set; }

        public int? DeptId { get; set; }

        public int? SuperiorEmpId { get; set; }

        public BranchDto Branch { get; set; }

        public DepartmentDto Department { get; set; }
    }
}
