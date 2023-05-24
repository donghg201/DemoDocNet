using Demo.Dto;
using Demo.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccTransactionController : ControllerBase
    {
        private readonly AccTransactionService _accTransactionService;

        public AccTransactionController(AccTransactionService accTransactionService)
        {
            _accTransactionService = accTransactionService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(this._accTransactionService.GetAllAccTransaction());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAccTransaction(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Not found id input!");
                }
                if (this._accTransactionService.GetAccTransactionById(id) == null)
                {
                    return NotFound("Not found acc transaction with id = " + id);
                }
                return Ok(this._accTransactionService.GetAccTransactionById(id));
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPost]
        public IActionResult Add([FromBody] AccTransactionDto accTransaction)
        {
            try
            {
                if (accTransaction == null)
                {
                    return BadRequest("Not found input!");
                }
                if (_accTransactionService.GetBranchById((int)accTransaction.ExecutionBranchId) == null)
                {
                    return NotFound("Not found brand with id = " + accTransaction.ExecutionBranchId);
                }
                if (_accTransactionService.GetEmployeeById((int)accTransaction.TellerEmpId) == null)
                {
                    return NotFound("Not found employee with id = "+ accTransaction.TellerEmpId);
                }
                if (_accTransactionService.GetAccountById((int)accTransaction.AccountId) == null)
                {
                    return NotFound("Not found account with id = " + accTransaction.AccountId);
                }
                if (!_accTransactionService.CompareAmountWithAvail(accTransaction.Amount, (int)accTransaction.AccountId))
                {
                    return BadRequest("Available must be equals to or greater than amount!");
                }
                this._accTransactionService.AddAccTransaction(accTransaction);
                return Ok(accTransaction);
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AccTransactionDto accTransaction)
        {
            try
            {
                if (accTransaction == null || id == 0)
                {
                    return BadRequest("Not found input!");
                }
                if (this._accTransactionService.GetAccTransactionById(id) == null)
                {
                    return NotFound("Not found account transaction with id = " + id);
                }
                else
                {
                    if (_accTransactionService.GetBranchById((int)accTransaction.ExecutionBranchId) == null)
                    {
                        return NotFound("Not found brand with id = " + accTransaction.ExecutionBranchId);
                    }
                    if (_accTransactionService.GetEmployeeById((int)accTransaction.TellerEmpId) == null)
                    {
                        return NotFound("Not found employee with id = " + accTransaction.TellerEmpId);
                    }
                    if (_accTransactionService.GetAccountById((int)accTransaction.AccountId) == null)
                    {
                        return NotFound("Not found account with id = " + accTransaction.AccountId);
                    }
                    if (!_accTransactionService.CompareAmountWithAvail(accTransaction.Amount, (int)accTransaction.AccountId))
                    {
                        return BadRequest("Available must be equals to or greater than amount!");
                    }
                }
                this._accTransactionService.UpdateAccTransaction(accTransaction, id);
                return Ok(accTransaction);
            }catch (Exception e) 
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
                if (this._accTransactionService.GetAccTransactionById(id) == null)
                {
                    return NotFound("Not found account transaction with id = " + id);
                }
                else
                {
                    this._accTransactionService.RemoveAccTransaction(id);
                    return Ok("Delete successfully!");
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
