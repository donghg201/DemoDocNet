using Demo.Dto;
using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly ProductTypeService _productTypeService;

        public ProductTypeController(ProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(this._productTypeService.GetAllProductType());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductType(string id)
        {
            if (id == null)
            {
                return BadRequest("Not found input!");
            }
            
            if (this._productTypeService.GetProductTypeById(id) == null)
            {
                return NotFound("Not found product type with id = "+ id);
            }
            return Ok(this._productTypeService.GetProductTypeById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductTypeDto productType)
        {
            if (productType == null)
            {
                return BadRequest("Not found input!");
            }
            if (this._productTypeService.GetProductTypeById(productType.ProductTypeCd) != null)
            {
                return BadRequest("Exist product type!");
            }
            this._productTypeService.AddProductType(productType);
            return Ok(productType);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ProductTypeDto productType)
        {
            if (productType == null || id == null)
            {
                return BadRequest("Not found input!");
            }
            if (this._productTypeService.GetProductTypeById(id) == null)
            {
                return NotFound("Not found productType!");
            }
            else
            {
                this._productTypeService.UpdateProductType(productType, id);
                return Ok(productType);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return BadRequest("Not found input!");
            }
            if (this._productTypeService.GetProductTypeById(id) == null)
            {
                return NotFound("Not found productType!");
            }
            else
            {
                this._productTypeService.RemoveProductType(id);
                return Ok("Delete successfully!");
            }
        }
    }
}
