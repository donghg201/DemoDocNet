using Demo.Models;
using Demo.Repositories.IRepositories;

namespace Demo.Uow.IUow
{
    public interface IEmployeeUow
    {
        IEmployeeRepository<Employee> EmployeeRepository { get; }
        IRepository<Branch> BranchRepository { get; }
        IRepository<Department> DepartmentRepository { get; }

        void SaveChanges();
    }
}
