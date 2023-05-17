using Demo.Dto;
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
            return Ok(this._employeeService.GetEmployeeById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] EmployeeDto employee)
        {
            if(_employeeService.GetBranchById((int)employee.AssignedBranchId) == null)
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
            return Ok("Create successfully!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeDto employee)
        {
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
            return Ok("Edit successfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
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
