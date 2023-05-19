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
            try
            {
                return Ok(this._productTypeService.GetAllProductType());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductType(string id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("Not found input!");
                }

                if (this._productTypeService.GetProductTypeById(id) == null)
                {
                    return NotFound("Not found product type with id = " + id);
                }
                return Ok(this._productTypeService.GetProductTypeById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductTypeDto productType)
        {
            try
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ProductTypeDto productType)
        {
            try
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
