using Demo.Dto;
using Demo.Models;
using Demo.Uow.IUow;

namespace Demo.Services
{
    public class AccountService
    {
        private readonly IAccountUow _uow;

        public AccountService(IAccountUow uow)
        {
            this._uow = uow;
        }

        public void AddAccount(AccountDto account)
        {
            Account _account = new()
            {
                AvailBalance = account.AvailBalance,
                CloseDate = account.CloseDate,
                LastActivityDate = account.LastActivityDate,
                OpenDate = account.OpenDate,
                PendingBalance = account.PendingBalance,
                Status = account.Status,
                CustId = account.CustId,
                OpenBranchId = account.OpenBranchId,
                OpenEmpId = account.OpenEmpId,
                ProductCd = account.ProductCd,
            };
            this._uow.AccountRepository.Add(_account);
            this._uow.SaveChanges();
        }

        public Branch GetBranchById(int id)
        {
            return this._uow.BranchRepository.FindById(id);
        }

        public Employee GetEmployeeById(int id)
        {
            return this._uow.EmployeeRepository.FindById(id);
        }

        public Customer GetCustomerById(int id)
        {
            return this._uow.CustomerRepository.FindById(id);
        }

        public Product GetProductById(string id)
        {
            return this._uow.ProductRepository.FindById(id);
        }
    }
}
