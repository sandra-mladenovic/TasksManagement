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
    public class GetStatusTypesQuery : IGetStatusTypesQuery
    {
        private readonly TasksManagementContext _context;
        public GetStatusTypesQuery(TasksManagementContext context)
        {
            _context = context;
        }
        public int Id => 17;

        public string Name => "Get StatusTypes";

        public PagedResponse<StatusTypeDto> Execute(StatusTypeSearch search)
        {
            var query = _context.StatusTypes.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);
            //Page == 1
            var response = new PagedResponse<StatusTypeDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(), //returns how many rows returns db that matches criterion
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new StatusTypeDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()

            };
            return response;
        }
    }
}
