using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class ProductType
    {
        [Key]
        [StringLength(10)]
        [Required]
        public string ProductTypeCd { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

    }
}
