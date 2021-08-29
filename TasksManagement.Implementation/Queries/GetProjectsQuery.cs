using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksManagement.Application.DataTransfer;
using TasksManagement.Application.Queries;
using TasksManagement.Application.Searches;
using TasksManagement.DataAccess;

namespace TasksManagement.Implementation.Queries
{
    public class GetProjectsQuery : IGetProjectsQuery
    {
        private readonly TasksManagementContext _context;
        public GetProjectsQuery(TasksManagementContext context)
        {
            _context = context;
        }
        public int Id => 3;

        public string Name => "Project search/get";

        public PagedResponse<ProjectDto> Execute(ProjectSearch search)
        {
            var query = _context.Projects.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);
            //Page == 1
            var response = new PagedResponse<ProjectDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(), //returns how many rows returns db that matches criterion
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new ProjectDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code
                }).ToList()

            };
            return  response;

        }
    }
}
