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

        private IEmployeeRepository<Employee> employeeRepository;
        public IEmployeeRepository<Employee> EmployeeRepository
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

        private IRepository<Branch> branchRepository;
        public IRepository<Branch> BranchRepository
        {
            get
            {
                if (branchRepository == null)
                {
                    branchRepository = new BranchRepository(_context);
                }
                return branchRepository;
            }
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

