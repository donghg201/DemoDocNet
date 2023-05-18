using Demo.Dto;
using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = this._taskService.GetListCustomerAccount(id);
            return Ok(result);
        }

        //private readonly MyDbContext _context;

        //public TaskController(MyDbContext context)
        //{
        //    this._context = context;
        //}


        //[HttpGet]
        //public IActionResult Get(int id)
        //{
        //    var customer = (from c in this._context.Customers
        //                    join a in this._context.Accounts on c.CustId equals a.CustId
        //                    join t in this._context.AccTransactions on a.AccountId equals t.AccountId
        //                    where c.CustId == id
        //                    select new CustomerAccountDto()
        //                    {
        //                        CustId = c.CustId,
        //                        Address = c.Address,
        //                        City = c.City,
        //                        CustTypeCd = c.CustTypeCd,
        //                        FedId = c.FedId,
        //                        PostalCode = c.PostalCode,
        //                        State = c.State,
        //                        AccountId = a.AccountId,
        //                        AvailBalance = a.AvailBalance,
        //                        CloseDate = a.CloseDate,
        //                        OpenDate = a.OpenDate,
        //                        LastActivityDate = a.LastActivityDate,
        //                        PendingBalance = a.PendingBalance,
        //                        Status = a.Status,
        //                        OpenBranchId = a.OpenBranchId,
        //                        OpenEmpId = a.OpenEmpId,
        //                        ProductCd = a.ProductCd,
        //                        TxnId = t.TxnId,
        //                        Amount = t.Amount,
        //                        FundsAvailDate = t.FundsAvailDate,
        //                        TxnDate = t.TxnDate,
        //                        TxnTypeCd = t.TxnTypeCd,
        //                        ExecutionBranchId = t.ExecutionBranchId,
        //                        TellerEmpId = t.TellerEmpId
        //                    }).ToList();
        //    return Ok(customer);
        //}
    }
}
