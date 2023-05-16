using Demo.Models;
using Demo.Repositories;
using Demo.Repositories.IRepositories;
using Demo.Uow.IUow;

namespace Demo.Uow
{
    public class CustomerUow : ICustomerUow
    {
        private readonly MyDbContext _context;

        public CustomerUow(MyDbContext context)
        {
            this._context = context;
        }

        private IRepository<Customer> customerRepository;
        public IRepository<Customer> CustomerRepository
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

        private IRepository<Bussiness> businessRepository;
        public IRepository<Bussiness> BusinessRepository
        {
            get
            {
                if (businessRepository == null)
                {
                    businessRepository = new BussinessRepository(_context);
                }
                return businessRepository;
            }
        }

        private IRepository<Individual> individualRepository;
        public IRepository<Individual> IndividualRepository
        {
            get
            {
                if (individualRepository == null)
                {
                    individualRepository = new IndividualRepository(_context);
                }
                return individualRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
