using Demo.Dto;
using Demo.Models;
using Demo.Repositories.IRepositories;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Repositories
{
    public class TaskRepository : ITaskRepository<CustomerTaskDto>
    {
        private readonly MyDbContext _context;

        public TaskRepository(MyDbContext context)
        {
            this._context = context;
        }

        public float SumAvail(int id)
        {
            float? sum = 0;
            var avail = (from c in this._context.Customers
                         join a in this._context.Accounts on c.CustId equals a.CustId
                         where c.CustId == id
                         select a.AvailBalance).ToList();
            foreach(var c in avail)
            {
                sum = sum + c;
            }
            return (float)sum;
        }

        public List<CustomerTaskDto> GetListCustomerById(int id)
        {
            var customer = (from c in this._context.Customers
                            join a in this._context.Accounts on c.CustId equals a.CustId
                            join t in this._context.AccTransactions on a.AccountId equals t.AccountId
                            join e in this._context.Employees on a.OpenEmpId equals e.EmpId
                            join b in this._context.Branchs on e.AssignedBranchId equals b.BranchId
                            join p in this._context.Products on a.ProductCd equals p.ProductCd
                            where c.CustId == id
                            select new CustomerTaskDto()
                            {
                                CustId = c.CustId,
                                Address = c.Address,
                                City = c.City,
                                SumAvail = SumAvail(id),
                                CustTypeCd = c.CustTypeCd.Equals("I")? "Individual": "Bussiness",
                                FedId = c.FedId,
                                PostalCode = c.PostalCode,
                                State = c.State,
                                Accounts = new()
                                {
                                    new AccountTaskDto()
                                    {
                                        AccountId = a.AccountId,
                                        NameEmp = e.FirstName + " " + e.LastName,
                                        BranchName = b.Name,
                                        ProductName = p.Name,
                                        ProductTypeCd = p.ProductTypeCd,
                                        AvailBalance = a.AvailBalance,
                                        OpenDate = a.OpenDate,
                                        CloseDate = a.CloseDate,
                                        LastActivityDate = a.LastActivityDate,
                                        PendingBalance = a.PendingBalance,
                                        Status = a.Status,
                                        AccTransaction = new()
                                        {
                                            new AccTransactionTaskDto()
                                            {
                                                TxnId = t.TxnId,
                                                NameEmp = e.FirstName +" "+ e.LastName,
                                                BranchName = b.Name,
                                                Amount = t.Amount,
                                                FundsAvailDate = t.FundsAvailDate,
                                                TxnDate = t.TxnDate,
                                                TxnTypeCd = t.TxnTypeCd
                                            }
                                        }

                                    }
                                }
                            }
                            ).ToList();
            return customer;

        }

        
    }
}
