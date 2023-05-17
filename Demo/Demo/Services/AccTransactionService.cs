﻿using Demo.Dto;
using Demo.Models;
using Demo.Uow.IUow;

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
    }
}