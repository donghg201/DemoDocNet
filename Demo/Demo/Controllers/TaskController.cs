﻿using Demo.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                if(id == 0)
                {
                    return BadRequest("Not found id input!");
                }
                var result = this._taskService.GetListCustomerAccount(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
