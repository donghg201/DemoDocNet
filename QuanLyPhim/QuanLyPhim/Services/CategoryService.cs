using QuanLyPhim.Models;
using QuanLyPhim.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyPhim.Services
{
    public class CategoryService
    {
        private readonly IUnitOfWork _uow;

        public CategoryService(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public void AddCategory(Category category)
        {
            this._uow.CategoryRepository.Add(category);
            this._uow.SaveChanges();
        }

        public List<Category> GetAllCategory()
        {
            return this._uow.CategoryRepository.FetchAll();
        }

        public Category GetCategoryById(int id)
        {
            return this._uow.CategoryRepository.FindById(id);
        }

        public void UpdateCategory(Category category, int id)
        {
            this._uow.CategoryRepository.Update(category, id);
            this._uow.SaveChanges();
        }

        public void RemoveCategory(int id)
        {
            this._uow.CategoryRepository.Delete(id);
            this._uow.SaveChanges();
        }
    }
}
