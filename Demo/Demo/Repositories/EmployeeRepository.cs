using Demo.Models;
using Demo.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Repositories
{
    public class EmployeeRepository : IEmployeeRepository<Employee>
    {
        private readonly MyDbContext _context;

        public EmployeeRepository(MyDbContext context)
        {
            this._context = context;
        }

        public Employee Add(Employee entity)
        {
            this._context.Employees.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var employee = (from e in _context.Employees
                          where e.EmpId == id
                          select e).FirstOrDefault();
            this._context.Employees.Remove(employee);
        }

        public List<Employee> FetchAll()
        {
            var employees = (from e in _context.Employees
                            select e).ToList();
            return employees;
        }

        public Employee FindById(int id)
        {
            var employee = (from e in _context.Employees
                            where e.EmpId == id
                            select e).FirstOrDefault();
            return employee;
        }

        public void Update(Employee entity, int id)
        {
            var employee = (from e in _context.Employees
                            where e.EmpId == id
                            select e).FirstOrDefault();
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.StartDate = entity.StartDate;
            employee.EndDate = entity.EndDate;
            employee.Title = entity.Title;
            employee.AssignedBranchId  = entity.AssignedBranchId;
            employee.DeptId = entity.DeptId;
            employee.SuperiorEmpId = entity.SuperiorEmpId;
        }

        public Employee FindBySupId(int id)
        {
            var employee = (from e in _context.Employees
                            where e.SuperiorEmpId == id
                            select e).FirstOrDefault();
            return employee;
        }
    }
}
