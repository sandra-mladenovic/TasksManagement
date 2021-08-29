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
    public class ProjectsController : Controller
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public ProjectsController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ProjectSearch search, [FromServices] IGetProjectsQuery query)
        {
            executor.ExecuteQuery(query, search);
            return View();
        }

        // GET: api/Projects/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get([FromRoute] int id, [FromServices] IGetOneProjectQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Projects
        [HttpPost]
        public IActionResult Post([FromBody] ProjectDto dto, [FromServices] ICreateProjectCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return RedirectToAction(nameof(Index));
        }
        //public IActionResult Create()
        //{
        //    return View();
        //}
        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProjectDto dto, [FromServices] IUpdateProjectCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteProjectCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
