using Demo.Dto;
using Demo.Models;
using Demo.Uow.IUow;
using System;
using System.Collections.Generic;

namespace Demo.Services
{
    public class AccTransactionService
    {
        private readonly IAccTransactionUow _uow;

        public AccTransactionService(IAccTransactionUow uow)
        {
            this._uow = uow;
        }

        public void AddAccTransaction(AccTransactionDto accTransaction)
        {
            AccTransaction _accTransaction = new()
            {
                Amount = accTransaction.Amount,
                FundsAvailDate = accTransaction.FundsAvailDate,
                TxnDate = accTransaction.TxnDate,
                TxnTypeCd = accTransaction.TxnTypeCd,
                AccountId = accTransaction.AccountId,
                ExecutionBranchId = accTransaction.ExecutionBranchId,
                TellerEmpId = accTransaction.TellerEmpId,
            };
            var account = this._uow.AccountRepository.FindById((int)accTransaction.AccountId);
            account.AvailBalance -= accTransaction.Amount;
            
            this._uow.AccTransactionRepository.Add(_accTransaction);
            this._uow.SaveChanges();
        }

        public bool CompareAmountWithAvail(float amount, int accountId)
        {
            var account = this._uow.AccountRepository.FindById(accountId);
            if(account.AvailBalance >= amount)
            {
                return true;
            }
            return false;
        }

        public Account GetAccountById(int id)
        {
            return this._uow.AccountRepository.FindById(id);
        }
        public Branch GetBranchById(int id)
        {
            return this._uow.BranchRepository.FindById(id);
        }

        public Employee GetEmployeeById(int id)
        {
            return this._uow.EmployeeRepository.FindById(id);
        }

        public List<AccTransactionGetDto> GetAllAccTransaction()
        {
            List<AccTransactionGetDto> result = new();
            var accTrans = this._uow.AccTransactionRepository.FetchAll();
            foreach (var accTran in accTrans)
            {
                var branch = this._uow.BranchRepository.FindById((int)accTran.ExecutionBranchId);
                var employee = this._uow.EmployeeRepository.FindById((int)accTran.TellerEmpId);
                var accTransactionGetDto = new AccTransactionGetDto()
                {
                    TxnId = accTran.TxnId,
                    Amount = accTran.Amount,
                    FundsAvailDate = accTran.FundsAvailDate,
                    TxnDate = accTran.TxnDate,
                    TxnTypeCd = accTran.TxnTypeCd,
                    Branch = new BranchDto()
                    {
                        BranchId = branch.BranchId,
                        Name = branch.Name,
                        Address = branch.Address,
                        City = branch.City,
                        ZipCode = branch.ZipCode,
                        State = branch.State,
                    },
                    Employee = new EmployeeGetDto()
                    {
                        EmpId = employee.EmpId,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        StartDate = employee.StartDate,
                        EndDate = employee.EndDate,
                        Title = employee.Title,
                        AssignedBranchId = employee.AssignedBranchId,
                        DeptId = employee.DeptId,
                        SuperiorEmpId = employee.SuperiorEmpId
                    }
                };
                result.Add(accTransactionGetDto);
            }
            return result;
        }

        public AccTransactionGetDto GetAccTransactionById(int id)
        {
            var accTran = this._uow.AccTransactionRepository.FindById(id);
            if(accTran == null)
            {
                return null;
            }
            var branch = this._uow.BranchRepository.FindById((int)accTran.ExecutionBranchId);
            var employee = this._uow.EmployeeRepository.FindById((int)accTran.TellerEmpId);
            var accTransactionGetDto = new AccTransactionGetDto()
            {
                TxnId = accTran.TxnId,
                Amount = accTran.Amount,
                FundsAvailDate = accTran.FundsAvailDate,
                TxnDate = accTran.TxnDate,
                TxnTypeCd = accTran.TxnTypeCd,
                Branch = new BranchDto()
                {
                    BranchId = branch.BranchId,
                    Name = branch.Name,
                    Address = branch.Address,
                    City = branch.City,
                    ZipCode = branch.ZipCode,
                    State = branch.State,
                },
                Employee = new EmployeeGetDto()
                {
                    EmpId = employee.EmpId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    StartDate = employee.StartDate,
                    EndDate = employee.EndDate,
                    Title = employee.Title,
                    AssignedBranchId = employee.AssignedBranchId,
                    DeptId = employee.DeptId,
                    SuperiorEmpId = employee.SuperiorEmpId
                }
            };
            return accTransactionGetDto;
        }

        public void UpdateAccTransaction(AccTransactionDto accTransaction, int id)
        {
            var accOld = _uow.AccTransactionRepository.FindById(id);
            if(accOld.Amount >= accTransaction.Amount)
            {
                var account = this._uow.AccountRepository.FindById((int)accTransaction.AccountId);
                account.AvailBalance = account.AvailBalance + Math.Abs(accOld.Amount - accTransaction.Amount);
                AccTransaction _accTransaction = new()
                {
                    Amount = accTransaction.Amount,
                    FundsAvailDate = accTransaction.FundsAvailDate,
                    TxnDate = accTransaction.TxnDate,
                    TxnTypeCd = accTransaction.TxnTypeCd,
                    AccountId = accTransaction.AccountId,
                    ExecutionBranchId = accTransaction.ExecutionBranchId,
                    TellerEmpId = accTransaction.TellerEmpId,
                };
                this._uow.AccTransactionRepository.Update(_accTransaction, id);
                this._uow.SaveChanges();
            }
            else
            {
                var account = this._uow.AccountRepository.FindById((int)accTransaction.AccountId);
                account.AvailBalance = account.AvailBalance - Math.Abs(accOld.Amount - accTransaction.Amount);
                AccTransaction _accTransaction = new()
                {
                    Amount = accTransaction.Amount,
                    FundsAvailDate = accTransaction.FundsAvailDate,
                    TxnDate = accTransaction.TxnDate,
                    TxnTypeCd = accTransaction.TxnTypeCd,
                    AccountId = accTransaction.AccountId,
                    ExecutionBranchId = accTransaction.ExecutionBranchId,
                    TellerEmpId = accTransaction.TellerEmpId,
                };
                this._uow.AccTransactionRepository.Update(_accTransaction, id);
                this._uow.SaveChanges();
            }
        }

        public void RemoveAccTransaction(int id)
        {
            this._uow.AccTransactionRepository.Delete(id);
            this._uow.SaveChanges();
        }
    }
}
