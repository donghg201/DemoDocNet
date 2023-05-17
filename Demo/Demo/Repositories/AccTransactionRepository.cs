using Demo.Models;
using Demo.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Repositories
{
    public class AccTransactionRepository : IRepositoryInt<AccTransaction>
    {
        private readonly MyDbContext _context;

        public AccTransactionRepository(MyDbContext context)
        {
            this._context = context;
        }

        public AccTransaction Add(AccTransaction entity)
        {
            this._context.AccTransactions.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<AccTransaction> FetchAll()
        {
            throw new System.NotImplementedException();
        }

        public AccTransaction FindById(int id)
        {
            var accTrans = (from a in _context.AccTransactions
                           where a.TxnId == id
                           select a).FirstOrDefault();
            return accTrans;
        }

        public void Update(AccTransaction entity, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
