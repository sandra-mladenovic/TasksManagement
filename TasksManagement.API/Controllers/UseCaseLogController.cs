using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksManagement.Application;
using TasksManagement.Application.Queries;
using TasksManagement.Application.Searches;
using TasksManagement.DataAccess;

namespace TasksManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseLogController : ControllerBase
    {
        private readonly TasksManagementContext _context;
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public UseCaseLogController(TasksManagementContext context, IApplicationActor actor, UseCaseExecutor executor)
        {
            _context = context;
            _actor = actor;
            _executor = executor;
        }

        // GET: api/UseCaseLog
        [HttpGet]
        public IActionResult Get([FromQuery] UseCaseSearchSearch search, [FromServices] IGetUseCaseLogQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }
    }
}
