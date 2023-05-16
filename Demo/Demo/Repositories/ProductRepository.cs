using Demo.Models;
using Demo.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Repositories
{
    public class ProductRepository : IRepositoryString<Product>
    {
        private readonly MyDbContext _context;

        public ProductRepository(MyDbContext context)
        {
            this._context = context;
        }

        public Product Add(Product entity)
        {
            this._context.Products.Add(entity);
            return entity;
        }

        public void Delete(string id)
        {
            var product = (from p in _context.Products
                          where p.ProductCd == id
                          select p).FirstOrDefault();
            this._context.Products.Remove(product);
        }

        public List<Product> FetchAll()
        {
            var products = (from p in _context.Products
                           select p).ToList();
            return products;
        }

        public Product FindById(string id)
        {
            var product = (from p in _context.Products
                           where p.ProductCd == id
                           select p).FirstOrDefault();
            return product;
        }

        public void Update(Product entity, string id)
        {
            var product = (from p in _context.Products
                          where p.ProductCd == id
                          select p).FirstOrDefault();
            product.DateOffered = entity.DateOffered;
            product.DateRetired = entity.DateRetired;
            product.Name = entity.Name;
            product.ProductTypeCd = entity.ProductTypeCd;
        }
    }
}
