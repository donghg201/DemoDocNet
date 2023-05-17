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

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(this._accountService.GetAllAccount());
        }

        [HttpGet("{id}")]
        public IActionResult GetBranch(int id)
        {
            return Ok(this._accountService.GetAccountById(id));
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

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AccountDto account)
        {
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
                return Ok("Edit successfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
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
