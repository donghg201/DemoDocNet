using Demo.Models;
using Demo.Repositories.IRepositories;
using System.Collections.Generic;

namespace Demo.Repositories
{
    public class AccountRepository : IAccountRepository<Account>
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
            throw new System.NotImplementedException();
        }

        public List<Account> FetchAll()
        {
            throw new System.NotImplementedException();
        }

        public Account FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Account FindBySupId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Account entity, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
