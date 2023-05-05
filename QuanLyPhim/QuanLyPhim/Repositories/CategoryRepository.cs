using QuanLyPhim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyPhim.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly MyDbContext _context;

        public CategoryRepository(MyDbContext context)
        {
            this._context = context;
        }

        public Category Add(Category entity)
        {
            this._context.Categories.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(cat => cat.Id == id);
            this._context.Categories.Remove(category);
        }

        public List<Category> FetchAll()
        {
            return this._context.Categories.ToList();
        }

        public Category FindById(int id)
        {
            return _context.Categories.FirstOrDefault(cat => cat.Id == id);
        }

        public void Update(Category entity, int id)
        {
            var category = _context.Categories.FirstOrDefault(cat => cat.Id == id);
            category.Name = entity.Name;
        }
    }
}
