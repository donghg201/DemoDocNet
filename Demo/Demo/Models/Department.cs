using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Department
    {
        [Key]
        [Required]
        public int DeptId { get; set; }

        [StringLength(20)]
        [Required]
        public string Name { get; set; }

    }
}
