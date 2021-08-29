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
    public class GetUseCaseLogQuery : IGetUseCaseLogQuery
    {
        private readonly TasksManagementContext _context;

        public GetUseCaseLogQuery(TasksManagementContext context)
        {
            _context = context;
        }

        public int Id => 11;

        public string Name => "Search/Get UseCaseLog";

        public PagedResponse<UseCaseLogDto> Execute(UseCaseSearchSearch search)
        {
            var query = _context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.UseCaseName) || !string.IsNullOrEmpty(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(search.Actor) || !string.IsNullOrEmpty(search.Actor))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<UseCaseLogDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new UseCaseLogDto
                {
                    UseCaseName = x.UseCaseName,
                    Actor = x.Actor,
                    Date = x.Date,
                    Data = x.Data,
                }).ToList()
            };

            return response;
        }
    }
}
