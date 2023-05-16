using Demo.Models;
using Demo.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Repositories
{
    public class DepartmentRepository : IRepositoryInt<Department>
    {
        private readonly MyDbContext _context;

        public DepartmentRepository(MyDbContext context)
        {
            this._context = context;
        }

        public Department Add(Department entity)
        {
            this._context.Departments.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var department = (from d in _context.Departments
                              where d.DeptId == id
                              select d).FirstOrDefault();
            this._context.Departments.Remove(department);
        }

        public List<Department> FetchAll()
        {
            var departments = (from d in _context.Departments
                          select d).ToList();
            return departments;
        }

        public Department FindById(int id)
        {
            var department = (from d in _context.Departments
                              where d.DeptId == id
                              select d).FirstOrDefault();
            return department;
        }

        public void Update(Department entity, int id)
        {
            var department = (from d in _context.Departments
                              where d.DeptId == id
                              select d).FirstOrDefault();
            department.Name = entity.Name;
        }
    }
}
