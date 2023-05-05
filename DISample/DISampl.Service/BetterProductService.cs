using DISample.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DISample.Services
{
    public class BetterProductService : IProductService
    {
        public List<ProductViewModel> GetAll()
        {
            return new List<ProductViewModel>
            {
                new ProductViewModel {Id = 1, Name = "Pen Drive Better"},
                new ProductViewModel {Id = 2, Name = "Memory Card Better"},
                new ProductViewModel {Id = 3, Name = "Mobile Phone Better"},
                new ProductViewModel {Id = 4, Name = "Tablet Better"},
                new ProductViewModel {Id = 5, Name = "Desktop PC Better"},
            };
        }
    }
}
