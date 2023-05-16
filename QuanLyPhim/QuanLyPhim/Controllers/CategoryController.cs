using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyPhim.Models;
using QuanLyPhim.Services;

namespace QuanLyPhim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return this._categoryService.GetAllCategory();
        }

        [HttpGet("{id}")]
        public Category GetSudent(int id)
        {
            return this._categoryService.GetCategoryById(id);
        }

        [HttpPost]
        public void Add([FromBody]Category category)
        {
            this._categoryService.AddCategory(category);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Category category)
        {
            this._categoryService.UpdateCategory(category, id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._categoryService.RemoveCategory(id);
        }
    }
}