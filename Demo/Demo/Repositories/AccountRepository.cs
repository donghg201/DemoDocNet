using Demo.Models;
using Demo.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Repositories
{
    public class AccountRepository : IRepositoryInt<Account>
    {
        private readonly MyDbContext _context;

        public AccountRepository(MyDbContext context)
        {
            this._context = context;
        }

        public Account Add(Account entity)
        {
            this._context.Accounts.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var account = (from a in _context.Accounts
                           where a.AccountId == id
                           select a).FirstOrDefault();
            this._context.Accounts.Remove(account);
        }

        public List<Account> FetchAll()
        {
            var accounts = (from a in _context.Accounts
                           select a).ToList();
            return accounts;
        }

        public Account FindById(int id)
        {
            var account = (from a in _context.Accounts
                             where a.AccountId == id
                             select a).FirstOrDefault();
            return account;
        }

        public void Update(Account entity, int id)
        {
            var account = (from a in _context.Accounts
                           where a.AccountId == id
                           select a).FirstOrDefault();
            account.AvailBalance = entity.AvailBalance;
            account.CloseDate = entity.CloseDate;
            account.LastActivityDate = entity.LastActivityDate;
            account.OpenDate = entity.OpenDate;
            account.PendingBalance = entity.PendingBalance;
            account.Status = entity.Status;
            account.CustId = entity.CustId;
            account.OpenBranchId = entity.OpenBranchId;
            account.OpenEmpId = entity.OpenEmpId;
            account.ProductCd = entity.ProductCd;
        }
    }
}
