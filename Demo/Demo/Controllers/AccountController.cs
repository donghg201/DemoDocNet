using Demo.Dto;
using Demo.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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
            try
            {
                return Ok(this._accountService.GetAllAccount());

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAccount(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Not found id input!");
                }
                if (this._accountService.GetAccountById(id) == null)
                {
                    return NotFound("Not found account with id = " + id);
                }
                return Ok(this._accountService.GetAccountById(id));
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPost]
        public IActionResult Add([FromBody] AccountDto account)
        {
            try
            {
                if (account == null)
                {
                    return NotFound("Not found input!");
                }
                if(account.OpenDate.Equals(null))
                {
                    return NotFound("Open Date can not be empty!");
                }
                if (_accountService.GetBranchById(account.OpenBranchId) == null || account.OpenBranchId == 0)
                {
                    return NotFound("Not found brand with id = " + account.OpenBranchId);
                }
                if (_accountService.GetProductById(account.ProductCd) == null || account.ProductCd == null)
                {
                    return NotFound("Not found product with cd = " + account.ProductCd);
                }
                if (_accountService.GetEmployeeById(account.OpenEmpId) == null || account.OpenEmpId == 0)
                {
                    return NotFound("Not found employee with id = " + account.OpenEmpId);
                }
                if (_accountService.GetCustomerById((int)account.CustId) == null || account.CustId == 0)
                {
                    return NotFound("Not found customer with id == " + account.CustId);
                }
                this._accountService.AddAccount(account);
                return Ok(account);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AccountDto account)
        {
            try
            {
                if (account == null || id == 0)
                {
                    return NotFound("Not found input!");
                }
                
                if (this._accountService.GetAccountById(id) == null)
                {
                    return NotFound("Not found customer with id == " + account.CustId);
                }
                else
                {
                    if (account.OpenDate.Equals(null))
                    {
                        return NotFound("Open Date can not be empty!");
                    }
                    if (_accountService.GetBranchById(account.OpenBranchId) == null || account.OpenBranchId == 0)
                    {
                        return NotFound("Not found brand with id = " + account.OpenBranchId);
                    }
                    if (_accountService.GetProductById(account.ProductCd) == null || account.ProductCd == null)
                    {
                        return NotFound("Not found product with cd = " + account.ProductCd);
                    }
                    if (_accountService.GetEmployeeById(account.OpenEmpId) == null || account.OpenEmpId == 0)
                    {
                        return NotFound("Not found employee with id = " + account.OpenEmpId);
                    }
                    if (_accountService.GetCustomerById((int)account.CustId) == null || account.CustId == 0)
                    {
                        return NotFound("Not found customer with id == " + account.CustId);
                    }
                }
                this._accountService.UpdateAccount(account, id);
                return Ok(account);
            }catch(Exception e)
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
                    return BadRequest("Not found id input!");
                }
                if (this._accountService.GetAccountById(id) == null)
                {
                    return NotFound("Not found branch with id == "+ id);
                }
                else
                {
                    this._accountService.RemoveAccount(id);
                    return Ok("Delete successfully!");
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
