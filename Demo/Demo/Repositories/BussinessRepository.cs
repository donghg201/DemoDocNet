using Demo.Models;
using Demo.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Repositories
{
    public class BussinessRepository : IBussinessRepository<Bussiness>
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

        public Bussiness GetBussinessByStateId(string id)
        {
            var bussiness = (from b in _context.Bussiness
                             where b.StateId == id
                             select b).FirstOrDefault();
            return bussiness;
        }

        public Bussiness FindById(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Bussiness entity, string id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public List<Bussiness> FetchAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
