using Demo.Dto;
using Demo.Models;
using Demo.Uow.IUow;
using System;

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
    }
}
