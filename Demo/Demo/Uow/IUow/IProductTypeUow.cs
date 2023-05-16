using Demo.Models;
using Demo.Repositories.IRepositories;

namespace Demo.Uow.IUow
{
    public interface IProductTypeUow
    {
        IProductTypeRepository<ProductType> ProductTypeRepository { get; }

        void SaveChanges();
    }
}
