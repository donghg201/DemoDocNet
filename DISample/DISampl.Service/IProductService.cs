using DISample.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DISample.Services
{
    public interface IProductService
    {
        List<ProductViewModel> GetAll();
    }
}
