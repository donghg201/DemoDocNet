using Demo.Models;
using Demo.Repositories.IRepositories;

namespace Demo.Uow.IUow
{
    public interface IAccTransactionUow
    {
        IRepositoryInt<Branch> BranchRepository { get; }
        IEmployeeRepository<Employee> EmployeeRepository { get; }
        IRepositoryInt<Account> AccountRepository { get; }
        IRepositoryInt<AccTransaction> AccTransactionRepository { get; }

        void SaveChanges();
    }
}
