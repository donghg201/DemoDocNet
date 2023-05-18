using Demo.Dto;
using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(this._employeeService.GetAllEmployee());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            if (id == null)
            {
                return BadRequest("Not found input!");
            }
            if (this._employeeService.GetEmployeeById(id) == null)
            {
                return NotFound("Not found employee with id = "+ id);
            }
            return Ok(this._employeeService.GetEmployeeById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] EmployeeDto employee)
        {
            if (employee == null)
            {
                return BadRequest("Not found input!");
            }
            if (_employeeService.GetBranchById((int)employee.AssignedBranchId) == null)
            {
                return NotFound("Not found brand id!");
            }
            if(_employeeService.GetDepartmentById((int)employee.DeptId) == null)
            {
                return NotFound("Not found department id!");
            }
            if(_employeeService.GetEmployeeBySupId((int)employee.SuperiorEmpId) != null)
            {
                return NotFound("Exist superior employee id!");
            }
            this._employeeService.AddEmployee(employee);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeAddDto employee)
        {
            if (employee == null || id == null)
            {
                return BadRequest("Not found input!");
            }
            if (this._employeeService.GetEmployeeById(id) == null)
            {
                return NotFound("Not found employee!");
            }
            else
            {
                if (_employeeService.GetBranchById((int)employee.AssignedBranchId) == null)
                {
                    return NotFound("Not found brand id!");
                }
                if (_employeeService.GetDepartmentById((int)employee.DeptId) == null)
                {
                    return NotFound("Not found department id!");
                }
                if (_employeeService.GetEmployeeBySupId((int)employee.SuperiorEmpId) != null)
                {
                    return NotFound("Exist superior employee id!");
                }
            }
            this._employeeService.UpdateEmployee(employee, id);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest("Not found input!");
            }
            if (this._employeeService.GetEmployeeById(id) == null)
            {
                return NotFound("Not found employee!");
            }
            else
            {
                this._employeeService.RemoveEmployee(id);
                return Ok("Delete successfully!");
            }
        }
    }
}
