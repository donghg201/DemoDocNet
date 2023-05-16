using Demo.Models;
using Demo.Repositories.IRepositories;

namespace Demo.Uow.IUow
{
    public interface IEmployeeUow
    {
        IRepository<Employee> EmployeeRepository { get; }

        void SaveChanges();
    }
}
