using Demo.Models;
using Demo.Repositories.IRepositories;
using Demo.Repositories;
using Demo.Uow.IUow;

namespace Demo.Uow
{
    public class AccountUow : IAccountUow
    {
        private readonly MyDbContext _context;

        public AccountUow(MyDbContext context)
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

        private IRepositoryInt<Branch> branchRepository;
        public IRepositoryInt<Branch> BranchRepository
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

        private IRepositoryString<Product> productRepository;
        public IRepositoryString<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(_context);
                }
                return productRepository;
            }
        }
        
        private IAccountRepository<Account> accountRepository;
        public IAccountRepository<Account> AccountRepository
        {
            get
            {
                if (accountRepository == null)
                {
                    accountRepository = new AccountRepository(_context);
                }
                return accountRepository;
            }
        }

        private IRepositoryInt<Customer> customerRepository;
        public IRepositoryInt<Customer> CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                {
                    customerRepository = new CustomerRepository(_context);
                }
                return customerRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
