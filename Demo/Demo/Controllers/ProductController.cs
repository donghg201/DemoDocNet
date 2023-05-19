using Demo.Dto;
using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
            try
            {
                return Ok(this._productService.GetAllProduct());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(string id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("Not found input!");
                }
                if (this._productService.GetProductById(id) == null)
                {
                    return NotFound("Not found product with id = " + id);
                }
                return Ok(this._productService.GetProductById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductDto product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Not found input!");
                }
                if (this._productService.GetProductById(product.ProductCd) != null)
                {
                    return BadRequest("Exist product!");
                }
                if (this._productService.GetProductTypeById(product.ProductTypeCd) == null)
                {
                    return BadRequest("Not exist product type cd!");
                }
                this._productService.AddProduct(product);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ProductDto product)
        {
            try
            {
                if (id == null || product == null)
                {
                    return BadRequest("Not found input!");
                }
                if (this._productService.GetProductById(id) == null)
                {
                    return NotFound("Not found product!");
                }
                else
                {
                    this._productService.UpdateProduct(product, id);
                    return Ok(product);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("Not found input!");
                }
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
