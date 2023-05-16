using Demo.Models;
using Demo.Repositories.IRepositories;

namespace Demo.Uow.IUow
{
    public interface IProductUow
    {
        IRepositoryString<Product> ProductRepository { get; }
        IRepositoryString<ProductType> ProductTypeRepository { get; }

        void SaveChanges();
    }
}
