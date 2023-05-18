using Demo.Dto;
using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(this._departmentService.GetAllDepartment());
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id)
        {
            if (id == null)
            {
                return BadRequest("Not found input!");
            }
            if(this._departmentService.GetDepartmentById(id) == null)
            {
                return NotFound("Not found department with id = " + id);
            }
            return Ok(this._departmentService.GetDepartmentById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] DepartmentDto department)
        {
            if (department == null)
            {
                return BadRequest("Not found input!");
            }
            this._departmentService.AddDepartment(department);
            return Ok(department);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DepartmentDto department)
        {
            if (department == null || id == null)
            {
                return BadRequest("Not found input!");
            }
            if (this._departmentService.GetDepartmentById(id) == null)
            {
                return NotFound("Not found department!");
            }
            else
            {
                this._departmentService.UpdateDepartment(department, id);
                return Ok(department);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest("Not found input!");
            }
            if (this._departmentService.GetDepartmentById(id) == null)
            {
                return NotFound("Not found department!");
            }
            else
            {
                this._departmentService.RemoveDepartment(id);
                return Ok("Delete successfully!");
            }
        }
    }
}
