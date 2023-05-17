using Demo.Dto;
using Demo.Models;
using Demo.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Repositories
{
    public class CustomerRepository : ICustomerRepository<Customer>
    {
        private readonly MyDbContext _context;

        public CustomerRepository(MyDbContext context)
        {
            this._context = context;
        }

        public Customer Add(Customer entity)
        {
            this._context.Customers.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var customer = (from c in _context.Customers
                            where c.CustId == id
                            select c).FirstOrDefault();
            this._context.Customers.Remove(customer);
        }

        public List<Customer> FetchAll()
        {
            var customers = (from c in _context.Customers
                            select c).ToList();
            return customers;
        }

        public Customer FindById(int id)
        {
            var customer = (from c in _context.Customers
                             where c.CustId == id
                             select c).FirstOrDefault();
            return customer;
        }

        public void Update(Customer entity, int id)
        {
            var customer = (from c in _context.Customers
                            where c.CustId == id
                            select c).FirstOrDefault();
            customer.Address = entity.Address;
            customer.City = entity.City;
            customer.PostalCode = entity.PostalCode;
            customer.CustTypeCd = entity.CustTypeCd;
            customer.FedId = entity.FedId;
            customer.State = entity.State;
        }
        
        public List<Customer> GetInfoCustomerIndividual(string name)
        {
            var customers = (from c in this._context.Customers
                             join i in this._context.Individuals on c.CustId equals i.CustId
                             where (name.Equals(i.LastName) || name.Equals(i.FirstName))
                             select new Customer
                             {
                                 CustId = c.CustId,
                                 Address = c.Address,
                                 City = c.City,
                                 CustTypeCd = c.CustTypeCd,
                                 Individuals = new()
                                 { 
                                     new Individual
                                     {
                                        FirstName = i.FirstName,
                                        LastName = i.LastName,
                                        BirthDate = i.BirthDate,
                                     }
                                 },
                             }).ToList();
            return customers;
        }

        public List<Customer> GetInfoCustomerBussiness(string name)
        {
            var customers = (from c in this._context.Customers
                             join b in this._context.Bussiness on c.CustId equals b.CustId
                             where name.Equals(b.Name)
                             select new Customer
                             {
                                 CustId = c.CustId,
                                 Address = c.Address,
                                 City = c.City,
                                 CustTypeCd = c.CustTypeCd,
                                 Bussiness = new()
                                 {
                                     new Bussiness
                                     {
                                        Name = b.Name,
                                        IncorpDate = b.IncorpDate,
                                     }
                                 }
                             }).ToList();
            return customers;
        }
    }
}
