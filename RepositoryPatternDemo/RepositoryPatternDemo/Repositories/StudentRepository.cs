using System.Collections.Generic;
using System.Linq;
using RepositoryPatternDemo.Data;

namespace RepositoryPatternDemo.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly SchoolDbContext _context;

        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public Student Add(Student entity)
        {
            _context.Students.Add(entity);
            return entity;
        }

        public List<Student> FetchAll()
        {
            return _context.Students.ToList();
        }

        public Student FindById(int id)
        {
            return _context.Students.FirstOrDefault(stu => stu.Id == id);
        }

        public void Update(Student entity, int id)
        {
            var student = _context.Students.FirstOrDefault(stu => stu.Id == id);
            student.Name = entity.Name;
        }

        public void Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(stu => stu.Id == id);
            _context.Students.Remove(student);
        }
    }
}
