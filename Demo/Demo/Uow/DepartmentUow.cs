using Demo.Models;
using Demo.Repositories;
using Demo.Repositories.IRepositories;
using Demo.Uow.IUow;

namespace Demo.Uow
{
    public class DepartmentUow : IDepartmentUow
    {
        private readonly MyDbContext _context;

        public DepartmentUow(MyDbContext context)
        {
            this._context = context;
        }

        private IRepository<Department> departmentRepository;
        public IRepository<Department> DepartmentRepository
        {
            get
            {
                if (departmentRepository == null)
                {
                    departmentRepository = new DepartmentRepository(_context);
                }
                return departmentRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
