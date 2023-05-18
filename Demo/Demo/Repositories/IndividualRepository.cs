using Demo.Models;
using Demo.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Repositories
{
    public class IndividualRepository : IIndividualRepository<Individual>
    {
        private readonly MyDbContext _context;

        public IndividualRepository(MyDbContext context)
        {
            this._context = context;
        }
      

        public Individual FindCusIndividualById(int id)
        {
            var customer = (from c in _context.Customers
                            join i in _context.Individuals on c.CustId equals i.CustId
                            where c.CustId == id
                            select i).FirstOrDefault();
            return customer;
        }

        public Individual Add(Individual entity)
        {
            this._context.Individuals.Add(entity);
            return entity;
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public List<Individual> FetchAll()
        {
            throw new System.NotImplementedException();
        }

        public Individual FindById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Individual GetIndividualByFirstName(string name)
        {
            var individual = (from i in this._context.Individuals
                              where i.FirstName == name
                              select i).FirstOrDefault();
            return individual;
        }

        public void Update(Individual entity, string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
