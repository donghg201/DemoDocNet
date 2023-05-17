using Demo.Dto;
using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] AccountDto account)
        {
            if (_accountService.GetBranchById(account.OpenBranchId) == null)
            {
                return NotFound("Not found brand id!");
            }
            if (_accountService.GetProductById(account.ProductCd) == null)
            {
                return NotFound("Not found product cd!");
            }
            if (_accountService.GetEmployeeById(account.OpenEmpId) == null)
            {
                return NotFound("Not found employee id!");
            }
            if(_accountService.GetCustomerById((int)account.CustId) == null)
            {
                return NotFound("Not found customer id!");
            }
            this._accountService.AddAccount(account);
            return Ok("Create successfully!");
        }
    }
}
