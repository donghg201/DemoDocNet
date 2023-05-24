using Demo.Dto;
using Demo.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly BranchService _branchService;

        public BranchController(BranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(this._branchService.GetAllBranch());
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBranch(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Not found id input!");
                }
                if (this._branchService.GetBranchById(id) == null)
                {
                    return NotFound("Not found branch with id = " + id);
                }
                return Ok(this._branchService.GetBranchById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] BranchDto branch)
        {
            try
            {
                if (branch == null)
                {
                    return NotFound("Not found input!");
                }
                if (branch.Name == "")
                {
                    return NotFound("Name of branch can not be empty!");
                }
                this._branchService.AddBranch(branch);
                return Ok(branch);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BranchDto branch)
        {
            try
            {
                if (branch == null || id == 0)
                {
                    return NotFound("Not found input!");
                }
                if (branch.Name == "")
                {
                    return NotFound("Name of branch can not be empty!");
                }
                if (this._branchService.GetBranchById(id) == null)
                {
                    return NotFound("Not found branch with id = " + id);
                }
                else
                {
                    this._branchService.UpdateBranch(branch, id);
                    return Ok(branch);
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
                    return NotFound("Not found input!");
                }
                if (this._branchService.GetBranchById(id) == null)
                {
                    return NotFound("Not found branch!");
                }
                else
                {
                    this._branchService.RemoveBranch(id);
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
