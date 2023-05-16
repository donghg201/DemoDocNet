using Demo.Models;
using Demo.Repositories;
using Demo.Repositories.IRepositories;
using Demo.Uow.IUow;

namespace Demo.Uow
{
    public class EmployeeUow : IEmployeeUow
    {
        private readonly MyDbContext _context;

        public EmployeeUow(MyDbContext context)
        {
            this._context = context;
        }

        private IRepository<Employee> employeeRepository;
        public IRepository<Employee> EmployeeRepository
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new EmployeeRepository(_context);
                }
                return employeeRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

