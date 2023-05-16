using Demo.Models;
using Demo.Repositories.IRepositories;
using System.Collections.Generic;

namespace Demo.Repositories
{
    public class BussinessRepository : IRepository<Bussiness>
    {
        private readonly MyDbContext _context;

        public BussinessRepository(MyDbContext context)
        {
            this._context = context;
        }

        public Bussiness Add(Bussiness entity)
        {
            this._context.Bussiness.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Bussiness> FetchAll()
        {
            throw new System.NotImplementedException();
        }

        public Bussiness FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Bussiness entity, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
