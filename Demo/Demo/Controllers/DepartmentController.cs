using Demo.Dto;
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
            return Ok(this._departmentService.GetDepartmentById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] DepartmentDto department)
        {
            this._departmentService.AddDepartment(department);
            return Ok("Create successfully!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DepartmentDto department)
        {
            if (this._departmentService.GetDepartmentById(id) == null)
            {
                return NotFound("Not found department!");
            }
            else
            {
                this._departmentService.UpdateDepartment(department, id);
                return Ok("Edit successfully!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
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
