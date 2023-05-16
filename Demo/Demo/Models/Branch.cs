using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Branch
    {
        [Key]
        [Required]
        [Range(0, 10)]
        //"^[0-9]{1,10}$" -- regex 10 ký tự số
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
