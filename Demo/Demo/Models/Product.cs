using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Product
    {
        [Key]
        [StringLength(10)]
        [Required]
        public string ProductCd { get; set; }

        public DateTime? DateOffered { get; set; }

        public DateTime? DateRetired { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(10)]
        [Required]
        public string? ProductTypeCd { get; set; }
        [ForeignKey("ProductTypeCd")]
        public ProductType ProductType { get; set; }
    }
}
