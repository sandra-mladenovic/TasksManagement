using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.DataTransfer;
using TasksManagement.Application.Exceptions;
using TasksManagement.Application.Queries;
using TasksManagement.DataAccess;
using TasksManagement.Domain;

namespace TasksManagement.Implementation.Queries
{
    public class GetOneUserQuery : IGetOneUserQuery
    {
        private readonly TasksManagementContext _context;

        public GetOneUserQuery(TasksManagementContext context)
        {
            _context = context;
        }
        public int Id => 8;

        public string Name => "Get one user";

        public UserDto Execute(int search)
        {
            var user = _context.Users.Find(search);

            if (user == null) throw new EntityNotFoundException(search, typeof(User));

            return new UserDto
            {
                Id = search,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password
            };
        }
    }
}
