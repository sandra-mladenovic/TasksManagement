using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.Commands;
using TasksManagement.Application.Exceptions;
using TasksManagement.DataAccess;
using TasksManagement.Domain;

namespace TasksManagement.Implementation.Commands
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly TasksManagementContext _context;

        public DeleteUserCommand(TasksManagementContext context)
        {
            _context = context;
        }
        public int Id => 9;

        public string Name => "Delete user";

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);

            if (user == null)
            {
                throw new EntityNotFoundException(request, typeof(User));
            }

            user.IsDeleted = true;
            user.IsActive = false;
            user.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
