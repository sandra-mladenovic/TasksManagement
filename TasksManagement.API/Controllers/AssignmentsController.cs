using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksManagement.Application;
using TasksManagement.Application.Commands;
using TasksManagement.Application.DataTransfer;
using TasksManagement.Application.Queries;
using TasksManagement.Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TasksManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public AssignmentsController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
        // GET: api/<AssignmentsController>
        [HttpGet]
        public IActionResult Get([FromQuery] AssignmentSearch search, [FromServices] IGetAssigmnentsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<AssignmentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AssignmentsController>
        [HttpPost]
        public void Post([FromBody] AssignmentDto dto, [FromServices] ICreateAssignmentCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT api/<AssignmentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AssignmentDto dto, [FromServices] IUpdateAssignmentCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<AssignmentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteAssignmentCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
