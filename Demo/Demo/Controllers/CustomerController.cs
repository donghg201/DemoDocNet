using Demo.Dto;
using Demo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                return Ok(this._customerService.GetAllCustomer());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Not found id input!");
                }
                if (this._customerService.GetCustomerById(id) == null)
                {
                    return NotFound("Not found customer with id = " + id);
                }
                return Ok(this._customerService.GetCustomerById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] CustomerDto customer)
        {
            try
            {
                if (customer == null)
                {
                    return NotFound("Not found input!");
                }

                if (customer.CustTypeCd == null)
                {
                    return NotFound("Not found Customer Type with cd = " + customer.CustTypeCd);
                }

                if (customer.FedId == null)
                {
                    return NotFound("Not found Fed Id with id = " + customer.FedId);
                }

                if (string.Equals(customer.CustTypeCd, "B") == true)
                {
                    // Để tránh trùng lập, check điều kiện khoá chính của bussiness -- StateId
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
                        IncorpDate = customer.IncorpDate,
                        Name = customer.Name,
                        State = customer.StateId,
                        PostalCode = customer.PostalCode,
                        FedId = customer.FedId,
                    });
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
                return BadRequest("CustTypeCd is not exacting!");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetInfoCustomer(string name)
        {
            try
            {
                if (name == "")
                {
                    return NotFound("Not found name input!");
                }
                List<CustomerDto> customerBussiness = this._customerService.GetInfoCustomerBussiness(name);
                List<CustomerDto> customerIndividual = this._customerService.GetInfoCustomerIndividual(name);
                foreach (CustomerDto customer in customerBussiness)
                {
                    customerIndividual.Add(customer);
                }
                if (customerIndividual.Count == 0)
                {
                    return NotFound("Not found with name " + name);
                }

                return Ok(customerIndividual);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerDto customer)
        {
            try
            {
                if (customer == null || id == 0)
                {
                    return NotFound("Not found input!");
                }
                if (customer.CustTypeCd == null)
                {
                    return NotFound("Not found Customer Type with cd = " + customer.CustTypeCd);
                }
                if (customer.FedId == null)
                {
                    return NotFound("Not found Fed Id with id = " + customer.FedId);
                }
                if (this._customerService.GetCustomerById(id) == null)
                {
                    return NotFound("Not found customer with id = " + id);
                }
                else
                {
                    var cusCheck = this._customerService.GetCustomerById(id);
                    if (cusCheck.CustTypeCd.Equals("B"))
                    {
                        if (string.Equals(customer.CustTypeCd, "B") == true)
                        {
                            if (this._customerService.GetBussinessByStateId(customer.StateId) == null)
                            {
                                return BadRequest("Not exist state id!");
                            }
                            this._customerService.EditCustomerBussiness(customer, id);
                            return Ok(new CustomerDto()
                            {
                                Address = customer.Address,
                                City = customer.City,
                                CustTypeCd = customer.CustTypeCd,
                                IncorpDate = customer.IncorpDate,
                                Name = customer.Name,
                                State = customer.StateId,
                                PostalCode = customer.PostalCode,
                                FedId = customer.FedId,
                            });
                        }
                        else
                        {
                            return BadRequest("CusTypeId not match");
                        }
                    }


                    if (string.Equals(customer.CustTypeCd, "I") == true)
                    {
                        if (this._customerService.GetIndividualByFirstName(customer.FirstName) == null)
                        {
                            return BadRequest("Not exist first name!");
                        }
                        this._customerService.EditCustomerIndividual(customer, id);
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
                    else
                    {
                        return BadRequest("CusTypeId not match");
                    }
                }
                this._customerService.UpdateCustomer(customer, id);
                return Ok(customer);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Not found id input!");
                }
                if (this._customerService.GetCustomerById(id) == null)
                {
                    return NotFound("Not found customer with id = " + id);
                }
                else
                {
                    this._customerService.RemoveCustomer(id);
                    return Ok("Delete successfully!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
