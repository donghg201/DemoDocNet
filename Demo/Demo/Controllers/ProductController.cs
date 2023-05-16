using Demo.Dto;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(this._productService.GetAllProduct());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(string id)
        {
            return Ok(this._productService.GetProductById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductDto product)
        {
            if(this._productService.GetProductTypeById(product.ProductTypeCd) != null)
            {
                return BadRequest("Not exist product type cd!");
            }
            this._productService.AddProduct(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ProductDto product)
        {
            if (this._productService.GetProductById(id) == null)
            {
                return NotFound("Not found product!");
            }
            else
            {
                this._productService.UpdateProduct(product, id);
                return Ok("Edit successfully!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (this._productService.GetProductById(id) == null)
            {
                return NotFound("Not found product!");
            }
            else
            {
                this._productService.RemoveProduct(id);
                return Ok("Delete successfully!");
            }
        }
    }
}
