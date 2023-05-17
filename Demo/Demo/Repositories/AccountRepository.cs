﻿using Demo.Models;
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
            throw new System.NotImplementedException();
        }

        public List<Account> FetchAll()
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}