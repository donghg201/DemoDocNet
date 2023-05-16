using Demo.Models;
using Demo.Repositories;
using Demo.Repositories.IRepositories;
using Demo.Uow.IUow;

namespace Demo.Uow
{
    public class ProductTypeUow : IProductTypeUow
    {
        private readonly MyDbContext _context;

        public ProductTypeUow(MyDbContext context)
        {
            this._context = context;
        }

        private IRepositoryString<ProductType> productTypeRepository;
        public IRepositoryString<ProductType> ProductTypeRepository
        {
            get
            {
                if (productTypeRepository == null)
                {
                    productTypeRepository = new ProductTypeRepository(_context);
                }
                return productTypeRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
