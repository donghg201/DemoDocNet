using Demo.Models;
using Demo.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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
            var individual = (from c in _context.Customers
                              join i in _context.Individuals on c.CustId equals i.CustId
                              where i.CustId.Equals(id)
                              select i).FirstOrDefault();
            return individual;
        }

        public Individual Add(Individual entity)
        {
            this._context.Individuals.Add(entity);
            return entity;
        }

        public void Delete(string id)
        {
            var individual = (from i in this._context.Individuals
                              where i.FirstName.Equals(id)
                              select i).FirstOrDefault();
            _context.Individuals.Remove(individual);
        }

        public List<Individual> FetchAll()
        {
            throw new System.NotImplementedException();
        }

        public Individual FindById(string id)
        {
            var individual = (from i in this._context.Individuals
                              where i.FirstName.Equals(id)
                              select i).FirstOrDefault();
            return individual;
        }

        public Individual GetIndividualByFirstName(string name)
        {
            var individual = (from i in this._context.Individuals
                              join c in _context.Customers on i.CustId equals c.CustId
                              where i.FirstName.Equals(name)
                              select i).FirstOrDefault();
            return individual;
        }

        public void Update(Individual entity, string id)
        {
            var individual = (from i in this._context.Individuals
                              where i.FirstName.Equals(id)
                              select i).FirstOrDefault();
            individual.LastName = entity.LastName;
            individual.BirthDate = entity.BirthDate;
        }
    }
}
