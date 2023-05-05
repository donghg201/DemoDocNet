using System.Collections.Generic;
using RepositoryPatternDemo.Data;
using RepositoryPatternDemo.Repositories;

namespace RepositoryPatternDemo.Services
{
    public class StudentService
    {
        //private readonly IRepository<Student> _repository;

        //public StudentService(IRepository<Student> repository)
        //{
        //    _repository = repository;
        //}

        private readonly IUnitOfWork uow;

        public StudentService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddStudent(Student student)
        {
            this.uow.StudentRepository.Add(student);
            this.uow.SaveChanges();
        } 

        public List<Student> GetAllStudent()
        {
            return this.uow.StudentRepository.FetchAll();
        }

        public Student GetStudentById(int id)
        {
            return this.uow.StudentRepository.FindById(id);
        }

        public void UpdateStudent(Student entity, int id)
        {
            this.uow.StudentRepository.Update(entity, id);
            this.uow.SaveChanges();
        }

        public void RemoveStudent(int id)
        {
            this.uow.StudentRepository.Delete(id);
            this.uow.SaveChanges();
        }
    }
}
