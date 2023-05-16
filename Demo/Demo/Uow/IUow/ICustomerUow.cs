using Demo.Models;
using Demo.Repositories.IRepositories;

namespace Demo.Uow.IUow
{
    public interface ICustomerUow
    {
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Bussiness> BusinessRepository { get; }
        IRepository<Individual> IndividualRepository { get; }

        void SaveChanges();
    }
}
