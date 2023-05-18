using Demo.Dto;
using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

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

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(this._accountService.GetAllAccount());
        }

        [HttpGet("{id}")]
        public IActionResult GetAccount(int id)
        {
            if (id == null)
            {
                return BadRequest("Not found input!");
            }
            if(this._accountService.GetAccountById(id) == null)
            {
                return NotFound("Not found account with id = " + id);
            }
            return Ok(this._accountService.GetAccountById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] AccountDto account)
        {
            if (account == null)
            {
                return BadRequest("Not found input!");
            }
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
            return Ok(account);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AccountDto account)
        {
            if (account == null || id == null)
            {
                return BadRequest("Not found input!");
            }
            if (this._accountService.GetAccountById(id) == null)
            {
                return NotFound("Not found account!");
            }
            else
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
                if (_accountService.GetCustomerById((int)account.CustId) == null)
                {
                    return NotFound("Not found customer id!");
                }
            }
                this._accountService.UpdateAccount(account, id);
                return Ok(account);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest("Not found input!");
            }
            if (this._accountService.GetAccountById(id) == null)
            {
                return NotFound("Not found branch!");
            }
            else
            {
                this._accountService.RemoveAccount(id);
                return Ok("Delete successfully!");
            }
        }
    }
}
