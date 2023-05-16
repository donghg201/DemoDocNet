using Demo.Dto;
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
                this._customerService.AddCustomerBusiness(customer);
                return Ok("Create successfully!");
            }

            if (string.Equals(customer.CustTypeCd, "I") == true)
            {
                // Để tránh trùng lập, check điều kiện khoá chính của individual -- StateId
                this._customerService.AddCustomerIndividual(customer);
                return Ok("Create successfully!");
            }
            return BadRequest("Not found CustTypeCd!");
        }
    }
}
