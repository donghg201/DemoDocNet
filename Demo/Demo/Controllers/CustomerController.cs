﻿using Demo.Dto;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                    FedId = customer.FedId,
                    PostalCode = customer.PostalCode,
                    State = customer.State,
                    StateId = customer.StateId,
                    IncorpDate = customer.IncorpDate,
                    Name = customer.Name
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
                    FedId = customer.FedId,
                    PostalCode = customer.PostalCode,
                    State = customer.State,
                    BirthDate = customer.BirthDate,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                });
            }
            return BadRequest("Not found CustTypeCd!");
        }
    }
}
