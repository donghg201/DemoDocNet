using Demo.Dto;
using Demo.Models;
using Demo.Uow.IUow;

namespace Demo.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeUow _uow;

        public EmployeeService(IEmployeeUow uow)
        {
            this._uow = uow;
        }

        public void AddEmployee(EmployeeDto employee)
        {
            Employee _employee = new()
            {
                //FirstName = employee.FirstName,
                //LastName = employee.LastName,
                //StartDate = employee.StartDate,
                //EndDate = employee.EndDate,
                //Title = employee.Title,
                //AssignedBranchId = employee.AssignedBranchId,
                //DeptId = employee.DeptId,
                //SuperiorEmpId = employee.SuperiorEmpId,
            };
            this._uow.EmployeeRepository.Add(_employee);
            this._uow.SaveChanges();
        }
    }
}
