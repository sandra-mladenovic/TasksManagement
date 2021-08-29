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
    public class GetRolesQuery : IGetRolesQuery
    {
        private readonly TasksManagementContext _context;
        public GetRolesQuery(TasksManagementContext context)
        {
            _context = context;
        }

        public int Id => 16;

        public string Name => "Get Roles";

        public PagedResponse<RoleDto> Execute(RolesSearch search)
        {
            var query = _context.Roles.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);
            //Page == 1
            var response = new PagedResponse<RoleDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(), //returns how many rows returns db that matches criterion
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new RoleDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()

            };
            return response;
        }
    }
}
