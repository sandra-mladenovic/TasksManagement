using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.Commands;
using TasksManagement.Application.DataTransfer;
using TasksManagement.DataAccess;
using TasksManagement.Domain;
using TasksManagement.Implementation.Validators;

namespace TasksManagement.Implementation.Commands
{
    public class CreateRoleCommand : ICreateRoleCommand
    {
        private readonly TasksManagementContext _context;
        private readonly UpsertRoleValidator _validate;
        public CreateRoleCommand(TasksManagementContext context, UpsertRoleValidator validate)
        {
            _context = context;
            _validate = validate;
        }

        public int Id => 18;

        public string Name => "Create Role";

        public void Execute(RoleDto request)
        {
            _validate.ValidateAndThrow(request); //ValidationException
            var role = new Role
            {
                Name = request.Name
            };

            _context.Roles.Add(role);
            _context.SaveChanges();
        }
    }
}
