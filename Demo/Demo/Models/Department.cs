using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Department
    {
        [Key]
        [Range(0, 10)]
        [Required]
        public int DeptId { get; set; }

        [StringLength(20)]
        [Required]
        public string Name { get; set; }

    }
}
