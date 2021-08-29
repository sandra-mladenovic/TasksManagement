using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.Commands;
using TasksManagement.Application.DataTransfer;
using TasksManagement.Application.Email;
using TasksManagement.DataAccess;
using TasksManagement.Domain;
using TasksManagement.Implementation.Validators;

namespace TasksManagement.Implementation.Commands
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly TasksManagementContext _context;
        private readonly UpsertUserValidator _validator;
        private readonly IEmailSender _sender;

        public CreateUserCommand(TasksManagementContext context, UpsertUserValidator validator, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            this._sender = sender;
        }

        public int Id => 6;

        public string Name => "Create new user";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                Username = request.Username,
                RoleId = request.RoleId
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            _sender.Send(new SendEmailDto
            {
                Content = $"<h1>Successfull Created  Registered for user {request.Username}!</h1>",
                SendTo = request.Email,
                Subject = "Registration"
            });
        }
    }
}
