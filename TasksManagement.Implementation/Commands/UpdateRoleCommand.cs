using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.Commands;
using TasksManagement.Application.DataTransfer;
using TasksManagement.Application.Exceptions;
using TasksManagement.DataAccess;
using TasksManagement.Domain;
using TasksManagement.Implementation.Validators;

namespace TasksManagement.Implementation.Commands
{
    public class UpdateRoleCommand : IUpdateRoleCommand
    {
        private readonly TasksManagementContext _context;
        private readonly UpsertRoleValidator _validate;

        public UpdateRoleCommand(TasksManagementContext context, UpsertRoleValidator validate)
        {
            _context = context;
            _validate = validate;
        }

        public int Id => 20;

        public string Name => "Update Role";

        public void Execute(RoleDto request)
        {
            var user = _context.Roles.Find(request.Id);

            if (user == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Role));
            }

            _validate.ValidateAndThrow(request);

            user.Name = request.Name;

            _context.SaveChanges();
        }
    }
}
