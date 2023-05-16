using Demo.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Demo.Dto
{
    public class ProductDto
    {
        public string ProductCd { get; set; }

        public DateTime? DateOffered { get; set; }

        public DateTime? DateRetired { get; set; }

        public string Name { get; set; }

        public string? ProductTypeCd { get; set; }
    }
}
