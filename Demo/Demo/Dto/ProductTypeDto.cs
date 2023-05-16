using Demo.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Dto
{
    public class ProductTypeDto
    {
        public string ProductTypeCd { get; set; }
        public string? Name { get; set; }
    }
}
