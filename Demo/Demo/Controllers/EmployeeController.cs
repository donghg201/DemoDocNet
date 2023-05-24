using Demo.Dto;
using Demo.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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
            try
            {
                return Ok(this._employeeService.GetAllEmployee());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Not found id input!");
                }
                if (this._employeeService.GetEmployeeById(id) == null)
                {
                    return NotFound("Not found employee with id = " + id);
                }
                return Ok(this._employeeService.GetEmployeeById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] EmployeeAddDto employee)
        {
            try
            {
                if (employee == null)
                {
                    return NotFound("Not found input!");
                }
                if (employee.FirstName == "" || employee.FirstName == null)
                {
                    return NotFound("First name can not be empty");
                }
                if (employee.LastName == "" || employee.LastName == null)
                {
                    return NotFound("Last name can not be empty!");
                }
                if (employee.StartDate.Equals(null))
                {
                    return NotFound("Not found Start date!");
                }
                if (_employeeService.GetBranchById((int)employee.AssignedBranchId) == null)
                {
                    return NotFound("Not found brand with id = " + employee.AssignedBranchId);
                }
                if (_employeeService.GetDepartmentById((int)employee.DeptId) == null)
                {
                    return NotFound("Not found department with id = " + employee.DeptId);
                }
                if (_employeeService.GetEmployeeBySupId((int)employee.SuperiorEmpId) != null)
                {
                    return NotFound("Exist superior employee with id = " + employee.SuperiorEmpId);
                }
                this._employeeService.AddEmployee(employee);
                return Ok(employee);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeAddDto employee)
        {
            try
            {
                if (employee == null || id == 0)
                {
                    return BadRequest("Not found input!");
                }
                if (employee.FirstName == "" || employee.FirstName == null)
                {
                    return NotFound("First name can not be empty");
                }
                if (employee.LastName == "" || employee.LastName == null)
                {
                    return NotFound("Last name can not be empty!");
                }
                if (employee.StartDate.Equals(null))
                {
                    return NotFound("Not found Start date!");
                }
                if (this._employeeService.GetEmployeeById(id) == null)
                {
                    return NotFound("Not found employee with id = " + id);
                }
                else
                {
                    if (_employeeService.GetBranchById((int)employee.AssignedBranchId) == null)
                    {
                        return NotFound("Not found brand with id = " + employee.AssignedBranchId);
                    }
                    if (_employeeService.GetDepartmentById((int)employee.DeptId) == null)
                    {
                        return NotFound("Not found department with id = " + employee.DeptId);
                    }
                    if (_employeeService.GetEmployeeBySupId((int)employee.SuperiorEmpId) == null)
                    {
                        return NotFound("Superior employee with id = " + employee.SuperiorEmpId + " not match!");
                    }
                }
                this._employeeService.UpdateEmployee(employee, id);
                return Ok(employee);
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
                    return BadRequest("Not found id input!");
                }
                if (this._employeeService.GetEmployeeById(id) == null)
                {
                    return NotFound("Not found employee with id = " + id);
                }
                else
                {
                    this._employeeService.RemoveEmployee(id);
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
