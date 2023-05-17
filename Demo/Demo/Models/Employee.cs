using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Employee
    {
        [Key]
        [Range(0, 10)]
        [Required]
        public int EmpId { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(20)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(20)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [StringLength(20)]
        public string? Title { get; set; }

        [Range(0, 10)]
        public int? AssignedBranchId { get; set; }
        [ForeignKey("AssignedBranchId")]
        public Branch Branch { get; set; }

        [Range(0, 10)]
        public int? DeptId { get; set; }
        [ForeignKey("DeptId")]
        public Department Department { get; set; }

        [Range(0, 10)]
        public int? SuperiorEmpId { get; set; }
    }
}
