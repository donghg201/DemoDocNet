using Demo.Dto;
using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            return Ok(this._branchService.GetAllBranch());
        }

        [HttpGet("{id}")]
        public IActionResult GetBranch(int id)
        {
            return Ok(this._branchService.GetBranchById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] BranchDto branch)
        {
            this._branchService.AddBranch(branch);
            return Ok("Create successfully!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BranchDto branch)
        {
            if(this._branchService.GetBranchById(id) == null)
            {
                return NotFound("Not found branch!");
            }
            else
            {
                this._branchService.UpdateBranch(branch, id);
                return Ok("Edit successfully!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(this._branchService.GetBranchById(id) == null)
            {
                return NotFound("Not found branch!");
            }
            else
            {
                this._branchService.RemoveBranch(id);
                return Ok("Delete successfully!");
            }
        }

    }
}
