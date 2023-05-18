using Demo.Dto;
using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(this._accTransactionService.GetAllAccTransaction());
        }

        [HttpGet("{id}")]
        public IActionResult GetAccTransaction(int id)
        {
            if (id == null)
            {
                return BadRequest("Not found input!");
            }
            if(this._accTransactionService.GetAccTransactionById(id) == null)
            {
                return NotFound("Not found acc transaction with id = "+ id);
            }
            return Ok(this._accTransactionService.GetAccTransactionById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] AccTransactionDto accTransaction)
        {
            if (accTransaction == null)
            {
                return BadRequest("Not found input!");
            }
            if (_accTransactionService.GetBranchById((int)accTransaction.ExecutionBranchId) == null)
            {
                return NotFound("Not found brand id!");
            }
            if (_accTransactionService.GetEmployeeById((int)accTransaction.TellerEmpId) == null)
            {
                return NotFound("Not found employee id!");
            }
            if (_accTransactionService.GetAccountById((int)accTransaction.AccountId) == null)
            {
                return NotFound("Not found account id!");
            }
            if(!_accTransactionService.CompareAmountWithAvail(accTransaction.Amount, (int)accTransaction.AccountId))
            {
                return BadRequest("Available must be equals to or greater than amount!");
            }
            this._accTransactionService.AddAccTransaction(accTransaction);
            return Ok(accTransaction);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AccTransactionDto accTransaction)
        {
            if (accTransaction == null || id == null)
            {
                return BadRequest("Not found input!");
            }
            if (this._accTransactionService.GetAccTransactionById(id) == null)
            {
                return NotFound("Not found account transaction!");
            }
            else
            {
                if (_accTransactionService.GetBranchById((int)accTransaction.ExecutionBranchId) == null)
                {
                    return NotFound("Not found brand id!");
                }
                if (_accTransactionService.GetEmployeeById((int)accTransaction.TellerEmpId) == null)
                {
                    return NotFound("Not found employee id!");
                }
                if (_accTransactionService.GetAccountById((int)accTransaction.AccountId) == null)
                {
                    return NotFound("Not found account id!");
                }
                if (!_accTransactionService.CompareAmountWithAvail(accTransaction.Amount, (int)accTransaction.AccountId))
                {
                    return BadRequest("Available must be equals to or greater than amount!");
                }
            }
            this._accTransactionService.UpdateAccTransaction(accTransaction, id);
            return Ok(accTransaction);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest("Not found input!");
            }
            if (this._accTransactionService.GetAccTransactionById(id) == null)
            {
                return NotFound("Not found account transaction!");
            }
            else
            {
                this._accTransactionService.RemoveAccTransaction(id);
                return Ok("Delete successfully!");
            }
        }
    }
}
