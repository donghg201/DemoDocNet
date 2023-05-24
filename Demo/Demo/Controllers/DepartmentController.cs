using Demo.Dto;
using Demo.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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
            try
            {
                return Ok(this._departmentService.GetAllDepartment());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Not found input!");
                }
                if (this._departmentService.GetDepartmentById(id) == null)
                {
                    return NotFound("Not found department with id = " + id);
                }
                return Ok(this._departmentService.GetDepartmentById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] DepartmentDto department)
        {
            try
            {
                if (department == null)
                {
                    return NotFound("Not found input!");
                }
                this._departmentService.AddDepartment(department);
                return Ok(department);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DepartmentDto department)
        {
            try
            {
                if (department == null || id == 0)
                {
                    return NotFound("Not found input!");
                }
                if (this._departmentService.GetDepartmentById(id) == null)
                {
                    return NotFound("Not found department with id = " + id);
                }
                else
                {
                    this._departmentService.UpdateDepartment(department, id);
                    return Ok(department);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Not found id input!");
                }
                if (this._departmentService.GetDepartmentById(id) == null)
                {
                    return NotFound("Not found department with id = " + id);
                }
                else
                {
                    this._departmentService.RemoveDepartment(id);
                    return Ok("Delete successfully!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
