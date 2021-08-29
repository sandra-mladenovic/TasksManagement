using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.Commands;
using TasksManagement.Application.Exceptions;
using TasksManagement.DataAccess;
using TasksManagement.Domain;

namespace TasksManagement.Implementation.Commands
{
    public class DeleteRoleCommand : IDeleteRoleCommand
    {
        private readonly TasksManagementContext _context;

        public DeleteRoleCommand(TasksManagementContext context)
        {
            _context = context;
        }

        public int Id => 22;

        public string Name => "Delete Role";

        public void Execute(int request)
        {
            var role = _context.Roles.Find(request);

            if (role == null)
            {
                throw new EntityNotFoundException(request, typeof(Role));
            }

            role.IsDeleted = true;
            role.IsActive = false;
            role.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
