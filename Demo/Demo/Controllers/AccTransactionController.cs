using Demo.Dto;
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

        [HttpPost]
        public IActionResult Add([FromBody] AccTransactionDto accTransaction)
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
            if(!_accTransactionService.CompareAmountWithAvail(accTransaction.Amount, (int)accTransaction.AccountId))
            {
                return BadRequest("Available must be equals to or greater than amount!");
            }
            this._accTransactionService.AddAccTransaction(accTransaction);
            return Ok("Create successfully!");
        }
    }
}
