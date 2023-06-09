﻿using Demo.Models;
using Demo.Repositories.IRepositories;

namespace Demo.Uow.IUow
{
    public interface IAccountUow
    {
        ICustomerRepository<Customer> CustomerRepository { get; }
        IRepositoryString<Product> ProductRepository { get; }
        IRepositoryInt<Branch> BranchRepository { get; }
        IEmployeeRepository<Employee> EmployeeRepository { get; }
        IRepositoryInt<Account> AccountRepository { get; }

        void SaveChanges();
    }
}
