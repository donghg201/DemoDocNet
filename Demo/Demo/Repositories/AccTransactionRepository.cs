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
            var accTrans = (from a in _context.AccTransactions
                            where a.TxnId == id
                            select a).FirstOrDefault();
            this._context.AccTransactions.Remove(accTrans);
        }

        public List<AccTransaction> FetchAll()
        {
            var accTrans = (from a in _context.AccTransactions
                            select a).ToList();
            return accTrans;
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
            var accTrans = (from a in _context.AccTransactions
                            where a.TxnId == id
                            select a).FirstOrDefault();
            accTrans.Amount = entity.Amount;
            accTrans.FundsAvailDate = entity.FundsAvailDate;
            accTrans.TxnDate = entity.TxnDate;
            accTrans.TxnTypeCd = entity.TxnTypeCd;
            accTrans.AccountId = entity.AccountId;
            accTrans.ExecutionBranchId = entity.ExecutionBranchId;
            accTrans.TellerEmpId = entity.TellerEmpId;
        }
    }
}
