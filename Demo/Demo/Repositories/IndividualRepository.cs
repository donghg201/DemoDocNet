using Demo.Models;
using Demo.Repositories.IRepositories;
using System.Collections.Generic;

namespace Demo.Repositories
{
    public class IndividualRepository : IRepository<Individual>
    {
        private readonly MyDbContext _context;

        public IndividualRepository(MyDbContext context)
        {
            this._context = context;
        }

        public Individual Add(Individual entity)
        {
            this._context.Individuals.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Individual> FetchAll()
        {
            throw new System.NotImplementedException();
        }

        public Individual FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Individual entity, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
