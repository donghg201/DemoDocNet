using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternDemo.Data;
using RepositoryPatternDemo.Services;


namespace RepositoryPatternDemo.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {

        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public List<Student> GetAll()
        {
            return this._studentService.GetAllStudent();
        }

        [HttpGet("{id}")]
        public Student GetSudent(int id)
        {
            return this._studentService.GetStudentById(id);
        }

        [HttpPost]
        public void Add([FromBody]Student student)
        {
            this._studentService.AddStudent(student);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Student student)
        {
            this._studentService.UpdateStudent(student, id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._studentService.RemoveStudent(id);
        }
    }
}
