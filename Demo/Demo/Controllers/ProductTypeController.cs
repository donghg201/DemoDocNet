using Demo.Dto;
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
            return Ok(this._productTypeService.GetProductTypeById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductTypeDto productType)
        {
            this._productTypeService.AddProductType(productType);
            return Ok("Create successfully!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ProductTypeDto productType)
        {
            if (this._productTypeService.GetProductTypeById(id) == null)
            {
                return NotFound("Not found productType!");
            }
            else
            {
                this._productTypeService.UpdateProductType(productType, id);
                return Ok("Edit successfully!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
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
