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
    public class GetUsersQuery : IGetUsersQuery
    {
        private readonly TasksManagementContext _context;

        public GetUsersQuery(TasksManagementContext context)
        {
            _context = context;
        }

        public int Id => 7;

        public string Name => "Get/search all users users";

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var query = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search.FirstName) || !string.IsNullOrEmpty(search.FirstName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(search.LastName) || !string.IsNullOrEmpty(search.LastName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
            }


            if (!string.IsNullOrWhiteSpace(search.Email) || !string.IsNullOrEmpty(search.Email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(search.Email.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(search.Username) || !string.IsNullOrEmpty(search.Username))
            {
                query = query.Where(x => x.Username.ToLower().Contains(search.Username.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<UserDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new UserDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Username = x.Username
                }).ToList()
            };

            return response;
        }
    }
}
