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
            throw new System.NotImplementedException();
        }

        public List<Employee> FetchAll()
        {
            throw new System.NotImplementedException();
        }

        public Employee FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Employee entity, int id)
        {
            throw new System.NotImplementedException();
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
