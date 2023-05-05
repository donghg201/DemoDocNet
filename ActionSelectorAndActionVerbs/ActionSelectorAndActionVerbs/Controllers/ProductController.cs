using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActionSelectorAndActionVerbs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActionSelectorAndActionVerbs.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //http://localhost:5001/product/edit
        //http://localhost:5001/product/modify

        //có thể chạy song song với nhau
        //[ActionName("modify")]
        //[Route("product/modify")] 


        //[NonAction]
        [HttpGet]
        public string Edit(string id)
        {
            return "Hello from edit product";
        }

        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public List<ProductModel> GetAll()
        {
            return new List<ProductModel>();
        }

        [HttpGet("{id}")]
        public List<ProductModel> GetAll(string id)
        {
            return new List<ProductModel>();
        }

        [HttpPost]
        public IActionResult Create(ProductModel model)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]ProductModel product)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok();
        }
    }
}