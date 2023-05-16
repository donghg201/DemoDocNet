using Demo.Models;
using Demo.Repositories.IRepositories;

namespace Demo.Uow.IUow
{
    public interface ICustomerUow
    {
        IRepositoryInt<Customer> CustomerRepository { get; }
        IBussinessRepository<Bussiness> BusinessRepository { get; }
        IIndividualRepository<Individual> IndividualRepository { get; }

        void SaveChanges();
    }
}
