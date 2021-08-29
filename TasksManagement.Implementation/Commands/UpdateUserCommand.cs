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
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly TasksManagementContext _context;
        private readonly UpsertUserValidator _validator;

        public UpdateUserCommand(TasksManagementContext context, UpsertUserValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 10;

        public string Name => "Update user";

        public void Execute(UserDto request)
        {
            var user = _context.Users.Find(request.Id);

            if (user == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(User));
            }

            _validator.ValidateAndThrow(request);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Password = request.Password;
            user.Username = request.Username;
            user.RoleId = request.RoleId;

            _context.SaveChanges();
        }
    }
}
