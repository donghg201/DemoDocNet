using Demo.Dto;
using Demo.Models;
using Demo.Uow.IUow;
using System;
using System.Collections.Generic;

namespace Demo.Services
{
    public class CustomerService
    {
        private readonly ICustomerUow _uow;

        public CustomerService(ICustomerUow uow)
        {
            this._uow = uow;
        }

        public void AddCustomerBusiness(CustomerDto customer)
        {
            Customer _customer = new()
            {
                Address = customer.Address,
                City = customer.City,
                CustTypeCd = customer.CustTypeCd,
                FedId = customer.FedId,
                PostalCode = customer.PostalCode,
                State = customer.State,
                Bussiness = new()
                {
                    new Bussiness
                    {
                        Name = customer.Name,
                        StateId = customer.StateId,
                        IncorpDate = customer.IncorpDate,
                    }
                }
            };

            this._uow.CustomerRepository.Add(_customer);
            this._uow.SaveChanges();
        }

        public void AddCustomerIndividual(CustomerDto customer)
        {
            Customer _customer = new()
            {
                Address = customer.Address,
                City = customer.City,
                CustTypeCd = customer.CustTypeCd,
                FedId = customer.FedId,
                PostalCode = customer.PostalCode,
                State = customer.State,
                Individuals = new()
                {
                    new Individual 
                    {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        BirthDate = customer.BirthDate,
                    }
                }
            };  

            this._uow.CustomerRepository.Add(_customer);
            this._uow.SaveChanges();
        }

        public Bussiness GetBussinessByStateId(string id)
        {
            return this._uow.BusinessRepository.GetBussinessByStateId(id);
        }

        public Individual GetIndividualByFirstName(string name)
        {
            return this._uow.IndividualRepository.GetIndividualByFirstName(name);
        }

        public List<Customer> GetInfoCustomerIndividual(string name)
        {
            return this._uow.CustomerRepository.GetInfoCustomerIndividual(name);
        }
        
        public List<Customer> GetInfoCustomerBussiness(string name)
        {
            //List<CustomerBussinessDto> result = new List<CustomerBussinessDto>();
            //List<Customer> customerList = this._uow.CustomerRepository.GetInfoCustomerBussiness(name);
            //foreach (var cus in customerList)
            //{
            //    CustomerBussinessDto customer = new()
            //    {
            //        Address = cus.Address,
            //        City = cus.City,
            //        CustTypeCd = cus.CustTypeCd,

            //    };
            //    result.Add(customer);
            //}
            //return result;
            return this._uow.CustomerRepository.GetInfoCustomerBussiness(name);

        }
        public List<Customer> GetAllCustomer()
        {
            return this._uow.CustomerRepository.FetchAll();
        }

        public Customer GetCustomerById(int id)
        {
            return this._uow.CustomerRepository.FindById(id);
        }

        public void UpdateCustomer(CustomerDto customer, int id)
        {

            Customer _customer = new()
            {
                Address = customer.Address,
                City = customer.City,
                PostalCode = customer.PostalCode,
                CustTypeCd = customer.CustTypeCd,
                FedId = customer.FedId,
                State = customer.State,
        };
            this._uow.CustomerRepository.Update(_customer, id);
            this._uow.SaveChanges();
        }

        public void RemoveCustomer(int id)
        {
            this._uow.CustomerRepository.Delete(id);
            this._uow.SaveChanges();
        }
    }
}
