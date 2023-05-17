using Demo.Models;
using Demo.Repositories;
using Demo.Repositories.IRepositories;
using Demo.Uow.IUow;
using Microsoft.EntityFrameworkCore;

namespace Demo.Uow
{
    public class AccTransactionUow : IAccTransactionUow
    {
        private readonly MyDbContext _context;

        public AccTransactionUow(MyDbContext context)
        {
            this._context = context;
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

        private IRepositoryInt<Account> accountRepository;
        public IRepositoryInt<Account> AccountRepository
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

        private IRepositoryInt<AccTransaction> accTransactionRepository;
        public IRepositoryInt<AccTransaction> AccTransactionRepository
        {
            get
            {
                if (accTransactionRepository == null)
                {
                    accTransactionRepository = new AccTransactionRepository(_context);
                }
                return accTransactionRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
