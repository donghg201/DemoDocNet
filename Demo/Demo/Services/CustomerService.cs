using Demo.Dto;
using Demo.Models;
using Demo.Uow.IUow;
using System.Collections.Generic;

namespace Demo.Services
{
    public class CustomerService
    {
        private readonly ICustomerUow _uow;
        private string i = "Individual";
        private string b = "Bussiness";

        public CustomerService(ICustomerUow uow)
        {
            this._uow = uow;
        }

        public void EditCustomerBussiness(CustomerDto customer,int id)
        {
            Customer _customer = new()
            {
                Address = customer.Address,
                City = customer.City,
                CustTypeCd = customer.CustTypeCd,
                State = customer.State,
                PostalCode = customer.PostalCode,
                FedId = customer.FedId
            };

            //var bussiness = _uow.BusinessRepository.GetBussinessByStateId(customer.StateId);
            Bussiness _bussiness = new()
            {
                Name = customer.Name,
                IncorpDate = customer.IncorpDate
            };

            _uow.BusinessRepository.Update(_bussiness, customer.StateId);
            _uow.CustomerRepository.Update(_customer, id);
            _uow.SaveChanges();
        }

        public void EditCustomerIndividual(CustomerDto customer, int id)
        {
            Customer _customer = new()
            {
                Address = customer.Address,
                City = customer.City,
                CustTypeCd = customer.CustTypeCd,
                State = customer.State,
                PostalCode = customer.PostalCode,
                FedId = customer.FedId
            };

            Individual _individual = new()
            {
                LastName = customer.LastName,
                BirthDate = customer.BirthDate
            };

            _uow.IndividualRepository.Update(_individual, customer.FirstName);
            _uow.CustomerRepository.Update(_customer, id);
            _uow.SaveChanges();
        }

        public void AddCustomerBusiness(CustomerDto customer)
        {
            Customer _customer = new()
            {
                Address = customer.Address,
                City = customer.City,
                CustTypeCd = customer.CustTypeCd,
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
                CustTypeCd = customer.CustTypeCd,
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
                    CustTypeCd = customer.CustTypeCd.Equals("I") ? i : b,
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
                    CustTypeCd = customer.CustTypeCd.Equals("I") ? i : b,
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
        public List<CustomerDto> GetAllCustomer()
        {
            CustomerDto customerDto;
            List<CustomerDto> customerDtoList = new();
            List<Customer> customerList = this._uow.CustomerRepository.FetchAll();
            foreach(var c in customerList)
            {
                if (c.CustTypeCd == "I")
                {
                    var customer = this._uow.CustomerRepository.FindById(c.CustId);
                    var individual = this._uow.IndividualRepository.FindCusIndividualById(c.CustId);
                    customerDto = new CustomerDto()
                    {
                        FirstName = individual.FirstName,
                        LastName = individual.LastName,
                        Address = customer.Address,
                        City = customer.City,
                        CustTypeCd = customer.CustTypeCd.Equals("I") ? i : b,
                        BirthDate = individual.BirthDate,
                        State = customer.State,
                        PostalCode = customer.PostalCode,
                        FedId = customer.FedId,
                    };
                }
                else
                {
                    var customer = this._uow.CustomerRepository.FindById(c.CustId);
                    var bussiness = this._uow.BusinessRepository.FindCusBussinessById(c.CustId);
                    customerDto = new CustomerDto()
                    {
                        Name = bussiness.Name,
                        Address = customer.Address,
                        City = customer.City,
                        CustTypeCd = customer.CustTypeCd.Equals("I") ? i : b,
                        IncorpDate = bussiness.IncorpDate,
                        StateId = bussiness.StateId,
                        State = customer.State,
                        PostalCode = customer.PostalCode,
                        FedId = customer.FedId
                    };
                }
                customerDtoList.Add(customerDto);
            }
            return customerDtoList;
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
                    CustTypeCd = customer.CustTypeCd.Equals("I") ? i : b,
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
                    CustTypeCd = customer.CustTypeCd.Equals("I") ? i : b,
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
                CustTypeCd = customer.CustTypeCd,
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
