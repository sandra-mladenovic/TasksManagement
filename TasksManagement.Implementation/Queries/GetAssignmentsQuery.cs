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
    public class GetAssignmentsQuery : IGetAssigmnentsQuery
    {
        private readonly TasksManagementContext _context;
        public GetAssignmentsQuery(TasksManagementContext context)
        {
            _context = context;
        }
        public int Id => 14;

        public string Name => "Get assignments";

        public PagedResponse<AssignmentDto> Execute(AssignmentSearch search)
        {
            var query = _context.Assignments.AsQueryable();

            if (!string.IsNullOrEmpty(search.Description) || !string.IsNullOrWhiteSpace(search.Description))
            {
                query = query.Where(x => x.Description.ToLower().Contains(search.Description.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);
            //Page == 1
            var response = new PagedResponse<AssignmentDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(), //returns how many rows returns db that matches criterion
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new AssignmentDto
                {
                    Id = x.Id,
                    Progress = x.Progress,
                    ProjectId = x.ProjectId,
                    UserId = x.UserId,
                    Deadline = x.Deadline,
                    StatusTypeId = x.StatusTypeId
                }).ToList()

            };
            return response;
        }
    }
}
