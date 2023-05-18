using Demo.Dto;
using Demo.Models;
using Demo.Uow.IUow;
using System.Collections.Generic;
using System.Net;
using System.Security.Principal;

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

        public List<AccountGetDto> GetAllAccount()
        {
            List<AccountGetDto> result = new();
            var accounts = this._uow.AccountRepository.FetchAll();
            foreach (var account in accounts)
            {
                var branch = this._uow.BranchRepository.FindById((int)account.OpenBranchId);
                var customer = this._uow.CustomerRepository.FindById((int)account.CustId);
                var employee = this._uow.EmployeeRepository.FindById(account.OpenEmpId);
                var product = this._uow.ProductRepository.FindById(account.ProductCd);
                var accountDto = new AccountGetDto()
                {
                    AccountId = account.AccountId,
                    AvailBalance = account.AvailBalance,
                    PendingBalance = account.PendingBalance,
                    OpenDate = account.OpenDate,
                    CloseDate = account.CloseDate,
                    LastActivityDate = account.LastActivityDate,
                    Status = account.Status,
                    Branch = new BranchDto()
                    {
                        BranchId = branch.BranchId,
                        Address = branch.Address,
                        Name = branch.Name,
                        City = branch.City,
                        ZipCode = branch.ZipCode,
                        State = branch.State,
                    },
                    Product = new ProductDto()
                    {
                        Name = product.Name,
                        ProductTypeCd = product.ProductTypeCd,
                        DateOffered = product.DateOffered,
                        DateRetired = product.DateRetired,
                        ProductCd = product.ProductCd,
                    },
                    Customer = new CustomerGetDto()
                    {
                        CustId = customer.CustId,
                        Address = customer.Address,
                        City = customer.City,
                        CustTypeCd = customer.CustTypeCd,
                        FedId = customer.FedId,
                        PostalCode = customer.PostalCode,
                        State = customer.State,
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
                        SuperiorEmpId = employee.SuperiorEmpId,
                    }
                };
                result.Add(accountDto);
            }
            return result;
        }

        public AccountGetDto GetAccountById(int id)
        {
            var account = this._uow.AccountRepository.FindById(id);
            if(account == null)
            {
                return null;
            }
            var branch = this._uow.BranchRepository.FindById((int)account.OpenBranchId);
            var customer = this._uow.CustomerRepository.FindById((int)account.CustId);
            var employee = this._uow.EmployeeRepository.FindById(account.OpenEmpId);
            var product = this._uow.ProductRepository.FindById(account.ProductCd);
            var accountDto = new AccountGetDto()
            {
                AccountId = account.AccountId,
                AvailBalance = account.AvailBalance,
                PendingBalance = account.PendingBalance,
                OpenDate = account.OpenDate,
                CloseDate = account.CloseDate,
                LastActivityDate = account.LastActivityDate,
                Status = account.Status,
                Branch = new BranchDto()
                {
                    BranchId = branch.BranchId,
                    Address = branch.Address,
                    Name = branch.Name,
                    City = branch.City,
                    ZipCode = branch.ZipCode,
                    State = branch.State,
                },
                Product = new ProductDto()
                {
                    Name = product.Name,
                    ProductTypeCd = product.ProductTypeCd,
                    DateOffered = product.DateOffered,
                    DateRetired = product.DateRetired,
                    ProductCd = product.ProductCd,
                },
                Customer = new CustomerGetDto()
                {
                    CustId = customer.CustId,
                    Address = customer.Address,
                    City = customer.City,
                    CustTypeCd = customer.CustTypeCd,
                    FedId = customer.FedId,
                    PostalCode = customer.PostalCode,
                    State = customer.State,
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
                    SuperiorEmpId = employee.SuperiorEmpId,
                }
            };
            return accountDto;
        }

        public void UpdateAccount(AccountDto account, int id)
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
            this._uow.AccountRepository.Update(_account, id);
            this._uow.SaveChanges();
        }

        public void RemoveAccount(int id)
        {
            this._uow.AccountRepository.Delete(id);
            this._uow.SaveChanges();
        }
    }
}
