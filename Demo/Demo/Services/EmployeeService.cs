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

        public void AddEmployee(EmployeeAddDto employee)
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

        public EmployeeDto GetEmployeeById(int id)
        {
            var employee = this._uow.EmployeeRepository.FindById(id);
            if(employee == null)
            {
                return null;
            }
            var branch = this._uow.BranchRepository.FindById((int)employee.AssignedBranchId);
            var department = this._uow.DepartmentRepository.FindById((int)employee.DeptId);

            EmployeeDto employeeDto = new EmployeeDto()
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
                Branch = new BranchDto()
                {
                    BranchId = branch.BranchId,
                    Address = branch.Address,
                    Name = branch.Name,
                    City = branch.City,
                    ZipCode = branch.ZipCode,
                    State = branch.State,
                },
                Department = new DepartmentDto()
                {
                    
                    Name = department.Name,
                }
            };
            return employeeDto;
        }

        public Employee GetEmployeeBySupId(int id)
        {
            return this._uow.EmployeeRepository.FindBySupId(id);
        }

        public List<EmployeeDto> GetAllEmployee()
        {
            List<EmployeeDto> result = new();
            var employees = this._uow.EmployeeRepository.FetchAll();
            foreach(var employee in employees)
            {
                var branch = this._uow.BranchRepository.FindById((int)employee.AssignedBranchId);
                var department = this._uow.DepartmentRepository.FindById((int)employee.DeptId);
                var employeeDto = new EmployeeDto()
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
                    Branch = new BranchDto()
                    {
                        BranchId = branch.BranchId,
                        Address = branch.Address,
                        Name = branch.Name,
                        City = branch.City,
                        ZipCode = branch.ZipCode,
                        State = branch.State,
                    },
                    Department = new DepartmentDto()
                    {

                        Name = department.Name,
                    }
                };
                result.Add(employeeDto);
            }
            return result;
        }

        public void UpdateEmployee(EmployeeAddDto employee, int id)
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
