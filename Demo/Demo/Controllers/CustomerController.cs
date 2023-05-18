using Demo.Dto;
using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("/api/customer/all")]
        public IActionResult GetAll()
        {
            return Ok(this._customerService.GetAllCustomer());
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            if (id == null)
            {
                return BadRequest("Not found input!");
            }
            if (this._customerService.GetCustomerById(id) == null)
            {
                return NotFound("Not found customer with id = " + id);
            }
            
            return Ok(this._customerService.GetCustomerById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] CustomerDto customer)
        {
            if (customer == null)
            {
                return BadRequest("Not found input!");
            }

            if (string.Equals(customer.CustTypeCd,"B") == true)
            {
                // Để tránh trùng lập, check điều kiện khoá chính của bussiness -- StateId
                if(this._customerService.GetBussinessByStateId(customer.StateId) != null)
                {
                    return BadRequest("Exist state id!");
                }
                this._customerService.AddCustomerBusiness(customer);
                return Ok(new CustomerDto()
                {
                    Address = customer.Address,
                    City = customer.City,
                    CustTypeCd = customer.CustTypeCd,
                    StateId = customer.StateId,
                    IncorpDate = customer.IncorpDate,
                    Name = customer.Name,
                    State = customer.StateId,
                    PostalCode = customer.PostalCode,
                    FedId = customer.FedId,
                }) ;
            }

            if (string.Equals(customer.CustTypeCd, "I") == true)
            {
                // Để tránh trùng lập, check điều kiện khoá chính của individual -- FirstName
                if (this._customerService.GetIndividualByFirstName(customer.FirstName) != null)
                {
                    return BadRequest("Exist first name!");
                }
                this._customerService.AddCustomerIndividual(customer);
                return Ok(new CustomerDto()
                {
                    Address = customer.Address,
                    City = customer.City,
                    CustTypeCd = customer.CustTypeCd,
                    BirthDate = customer.BirthDate,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    State = customer.StateId,
                    PostalCode = customer.PostalCode,
                    FedId = customer.FedId,
                });
            }
            return BadRequest("Not found CustTypeCd!");
        }

        [HttpGet]
        public IActionResult GetInfoCustomer(string name)
        {
            if (name == "")
            {
                return BadRequest("Not found input!");
            }
            List<CustomerDto> customerBussiness = this._customerService.GetInfoCustomerBussiness(name);
            List<CustomerDto> customerIndividual = this._customerService.GetInfoCustomerIndividual(name);
            foreach (CustomerDto customer in customerBussiness)
            {
                customerIndividual.Add(customer);
            }
            if(customerIndividual.Count == 0)
            {
                return NotFound("Not found with name "+ name);
            }
            
            return Ok(customerIndividual);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerDto customer)
        {
            if (customer == null || id == null)
            {
                return BadRequest("Not found input!");
            }
            if (this._customerService.GetCustomerById(id) == null)
            {
                return NotFound("Not found customer!");
            }
            else
            {
                if (string.Equals(customer.CustTypeCd, "B") == true)
                {
                    if (this._customerService.GetBussinessByStateId(customer.StateId) != null)
                    {
                        return BadRequest("Exist state id!");
                    }
                    this._customerService.AddCustomerBusiness(customer);
                    return Ok(new CustomerDto()
                    {
                        Address = customer.Address,
                        City = customer.City,
                        CustTypeCd = customer.CustTypeCd,
                        StateId = customer.StateId,
                        IncorpDate = customer.IncorpDate,
                        Name = customer.Name
                    });
                }

                if (string.Equals(customer.CustTypeCd, "I") == true)
                {
                    if (this._customerService.GetIndividualByFirstName(customer.FirstName) != null)
                    {
                        return BadRequest("Exist first name!");
                    }
                    this._customerService.AddCustomerIndividual(customer);
                    return Ok(new CustomerDto()
                    {
                        Address = customer.Address,
                        City = customer.City,
                        CustTypeCd = customer.CustTypeCd,
                        BirthDate = customer.BirthDate,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                    });
                }
            }
            this._customerService.UpdateCustomer(customer, id);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest("Not found input!");
            }
            if (this._customerService.GetCustomerById(id) == null)
            {
                return NotFound("Not found customer!");
            }
            else
            {
                this._customerService.RemoveCustomer(id);
                return Ok("Delete successfully!");
            }
        }
    }
}
