using Demo.Models;
using Demo.Repositories.IRepositories;
using Demo.Repositories;
using Demo.Uow.IUow;

namespace Demo.Uow
{
    public class ProductUow : IProductUow
    {
        private readonly MyDbContext _context;

        public ProductUow(MyDbContext context)
        {
            this._context = context;
        }

        private IRepositoryString<Product> productRepository;
        public IRepositoryString<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(_context);
                }
                return productRepository;
            }
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
