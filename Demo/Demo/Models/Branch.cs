using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Branch
    {
        [Key]
        [Required]
        public int BranchId { get; set; }

        [StringLength(30)]
        public string? Address { get; set; }

        [StringLength(20)]
        public string? City { get; set; }

        [StringLength(20)]
        [Required]
        public string Name { get; set; }

        [StringLength(10)]
        public string? State { get; set; }

        [StringLength(10)]
        public string? ZipCode { get; set; }

    }
}
