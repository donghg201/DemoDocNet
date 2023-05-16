using Demo.Models;
using Demo.Repositories.IRepositories;

namespace Demo.Uow.IUow
{
    public interface IEmployeeUow
    {
        IEmployeeRepository<Employee> EmployeeRepository { get; }
        IRepositoryInt<Branch> BranchRepository { get; }
        IRepositoryInt<Department> DepartmentRepository { get; }

        void SaveChanges();
    }
}
