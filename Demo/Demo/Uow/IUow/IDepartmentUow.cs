using Demo.Models;
using Demo.Repositories.IRepositories;

namespace Demo.Uow.IUow
{
    public interface IDepartmentUow
    {
        IRepository<Department> DepartmentRepository { get; }

        void SaveChanges();
    }
}
