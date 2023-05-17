using Demo.Models;
using Demo.Repositories.IRepositories;

namespace Demo.Uow.IUow
{
    public interface IAccountUow
    {
        IEmployeeRepository<Employee> EmployeeRepository { get; }
        IRepositoryInt<Branch> BranchRepository { get; }
        IRepositoryString<Product> ProductRepository { get; }
        IAccountRepository<Account> AccountRepository { get; }
        IRepositoryInt<Customer> CustomerRepository { get; }

        void SaveChanges();
    }
}
