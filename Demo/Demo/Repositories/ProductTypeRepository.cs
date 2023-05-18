using Demo.Models;
using Demo.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Repositories
{
    public class ProductTypeRepository : IRepositoryString<ProductType>
    {
        private readonly MyDbContext _context;

        public ProductTypeRepository(MyDbContext context)
        {
            this._context = context;
        }

        public ProductType Add(ProductType entity)
        {
            this._context.ProductTypes.Add(entity);
            return entity;
        }

        public void Delete(string id)
        {
            var productType = (from p in _context.ProductTypes
                               where p.ProductTypeCd == id
                               select p).FirstOrDefault();
            this._context.ProductTypes.Remove(productType);
        }

        public List<ProductType> FetchAll()
        {
            var productTypes = (from p in _context.ProductTypes
                               select p).ToList();
            return productTypes;
        }

        public ProductType FindById(string id)
        {
            var productType = (from p in _context.ProductTypes
                               where p.ProductTypeCd.Equals(id)
                               select p).FirstOrDefault();
            return productType;
        }

        public void Update(ProductType entity, string id)
        {
            var productType = (from p in _context.ProductTypes
                               where p.ProductTypeCd == id
                               select p).FirstOrDefault();
            productType.Name = entity.Name;
        }
    }
}
