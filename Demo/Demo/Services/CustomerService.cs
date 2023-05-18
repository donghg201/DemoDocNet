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
                CustTypeCd = customer.CustTypeCd.Equals("I") ? "Individual" : "Bussiness",
                State = customer.State,
                PostalCode = customer.PostalCode,
                FedId = customer.FedId,
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
                CustTypeCd = customer.CustTypeCd.Equals("I") ? "Individual" : "Bussiness",
                State = customer.State,
                PostalCode = customer.PostalCode,
                FedId = customer.FedId,
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

        public List<CustomerDto> GetInfoCustomerIndividual(string name)
        {
            CustomerDto customerDto;
            List<CustomerDto> customerDtoList = new();
            List<Customer> customerList = this._uow.CustomerRepository.GetInfoCustomerIndividual(name);
            foreach (Customer customer in customerList)
            {
                var individual = this._uow.IndividualRepository.FindCusIndividualById(customer.CustId);
                customerDto = new CustomerDto()
                {
                    Name = individual.FirstName + " " + individual.LastName,
                    Address = customer.Address,
                    City = customer.City,
                    CustTypeCd = customer.CustTypeCd.Equals("I") ? "Individual" : "Bussiness",
                    BirthDate = individual.BirthDate,
                    State = customer.State,
                    PostalCode = customer.PostalCode,
                    FedId = customer.FedId
                };
                customerDtoList.Add(customerDto);
            }
            return customerDtoList;
        }
        
        public List<CustomerDto> GetInfoCustomerBussiness(string name)
        {
            CustomerDto customerDto;
            List<CustomerDto> customerDtoList = new();
            List<Customer> customerList = this._uow.CustomerRepository.GetInfoCustomerBussiness(name);
            foreach(Customer customer in customerList)
            {
                var bussiness = this._uow.BusinessRepository.FindCusBussinessById(customer.CustId);
                customerDto = new CustomerDto()
                {
                    Name = bussiness.Name,
                    Address = customer.Address,
                    City = customer.City,
                    CustTypeCd = customer.CustTypeCd.Equals("I")?"Individual":"Bussiness",
                    StateId = bussiness.StateId,
                    IncorpDate = bussiness.IncorpDate,
                    State = customer.State,
                    PostalCode = customer.PostalCode,
                    FedId = customer.FedId
                };
                customerDtoList.Add(customerDto);
            }
            return customerDtoList;
        }
        public List<Customer> GetAllCustomer()
        {
            return this._uow.CustomerRepository.FetchAll();
        }

        public CustomerDto GetCustomerById(int id)
        {
            CustomerDto customerDto;
            var customer = this._uow.CustomerRepository.FindById(id);
            if(customer == null)
            {
                return null;
            }
            if (customer.CustTypeCd.Equals("I"))
            {
                var individual = this._uow.IndividualRepository.FindCusIndividualById(id);
                customerDto = new CustomerDto()
                {
                    FirstName = individual.FirstName,
                    LastName = individual.LastName,
                    Address = customer.Address,
                    City = customer.City,
                    CustTypeCd = customer.CustTypeCd.Equals("I") ? "Individual" : "Bussiness",
                    BirthDate = individual.BirthDate,
                    State = customer.State,
                    PostalCode = customer.PostalCode,
                    FedId = customer.FedId, 
                };
            }else
            {
                var bussiness = this._uow.BusinessRepository.FindCusBussinessById(id);
                customerDto = new CustomerDto()
                {
                    Name = bussiness.Name,
                    Address = customer.Address,
                    City = customer.City,
                    CustTypeCd = customer.CustTypeCd.Equals("I") ? "Individual" : "Bussiness",
                    IncorpDate = bussiness.IncorpDate,
                    StateId = bussiness.StateId,
                    State = customer.State,
                    PostalCode = customer.PostalCode,
                    FedId = customer.FedId
                };
            }
            return customerDto;
        }

        public void UpdateCustomer(CustomerDto customer, int id)
        {

            Customer _customer = new()
            {
                Address = customer.Address,
                City = customer.City,
                CustTypeCd = customer.CustTypeCd.Equals("I") ? "Individual" : "Bussiness",
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
