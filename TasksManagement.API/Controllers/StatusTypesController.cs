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
    public class StatusTypesController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public StatusTypesController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/<StatusTypesController>
        [HttpGet]
        public IActionResult Get([FromQuery] StatusTypeSearch search, [FromServices] IGetStatusTypesQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<StatusTypesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StatusTypesController>
        [HttpPost]
        public void Post([FromBody] StatusTypeDto dto, [FromServices] ICreateStatusTypeCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT api/<StatusTypesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StatusTypeDto dto, [FromServices] IUpdateStatusTypeCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<StatusTypesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteStatusTypeCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
