using Demo.Dto;
using Demo.Models;
using Demo.Uow.IUow;
using System.Collections.Generic;

namespace Demo.Services
{
    public class DepartmentService
    {
        private readonly IDepartmentUow _uow;

        public DepartmentService(IDepartmentUow uow)
        {
            this._uow = uow;
        }

        public void AddDepartment(DepartmentDto department)
        {
            Department _department = new()
            {
                Name = department.Name,
            };
            this._uow.DepartmentRepository.Add(_department);
            this._uow.SaveChanges();
        }

        public List<Department> GetAllDepartment()
        {
            return this._uow.DepartmentRepository.FetchAll();
        }

        public Department GetDepartmentById(int id)
        {
            return this._uow.DepartmentRepository.FindById(id);
        }

        public void UpdateDepartment(DepartmentDto department, int id)
        {

            Department _department = new()
            {
                Name = department.Name,
            };
            this._uow.DepartmentRepository.Update(_department, id);
            this._uow.SaveChanges();
        }

        public void RemoveDepartment(int id)
        {
            this._uow.DepartmentRepository.Delete(id);
            this._uow.SaveChanges();
        }
    }
}
