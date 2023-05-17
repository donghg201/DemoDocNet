using Demo.Dto;
using Demo.Models;
using Demo.Uow.IUow;
using System.Collections.Generic;

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
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                StartDate = employee.StartDate,
                EndDate = employee.EndDate,
                Title = employee.Title,
                AssignedBranchId = employee.AssignedBranchId,
                DeptId = employee.DeptId,
                SuperiorEmpId = employee.SuperiorEmpId,
            };
            this._uow.EmployeeRepository.Add(_employee);
            this._uow.SaveChanges();
        }

        public Branch GetBranchById(int id)
        {
            return this._uow.BranchRepository.FindById(id);
        }

        public Department GetDepartmentById(int id)
        {
            return this._uow.DepartmentRepository.FindById(id);
        }

        public Employee GetEmployeeById(int id)
        {
            return this._uow.EmployeeRepository.FindById(id);
        }

        public Employee GetEmployeeBySupId(int id)
        {
            return this._uow.EmployeeRepository.FindBySupId(id);
        }

        public List<Employee> GetAllEmployee()
        {
            return this._uow.EmployeeRepository.FetchAll();
        }

        public void UpdateEmployee(EmployeeDto employee, int id)
        {
            Employee _employee = new()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                StartDate = employee.StartDate,
                EndDate = employee.EndDate,
                Title = employee.Title,
                AssignedBranchId = employee.AssignedBranchId,
                DeptId = employee.DeptId,
                SuperiorEmpId = employee.SuperiorEmpId
        };
            this._uow.EmployeeRepository.Update(_employee, id);
            this._uow.SaveChanges();
        }

        public void RemoveEmployee(int id)
        {
            this._uow.EmployeeRepository.Delete(id);
            this._uow.SaveChanges();
        }
    }
}
