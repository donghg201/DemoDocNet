using Demo.Models;
using Demo.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Repositories
{
    public class CustomerRepository : IRepositoryInt<Customer>
    {
        private readonly MyDbContext _context;

        public CustomerRepository(MyDbContext context)
        {
            this._context = context;
        }

        public Customer Add(Customer entity)
        {
            this._context.Customers.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> FetchAll()
        {
            throw new System.NotImplementedException();
        }

        public Customer FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Customer entity, int id)
        {
            throw new System.NotImplementedException();
        }
        
        public Bussiness GetBussinessByStateId(string id)
        {
            var bussiness = (from b in _context.Bussiness
                             where b.StateId == id
                             select b).FirstOrDefault();
            return bussiness;
        }
    }
}
