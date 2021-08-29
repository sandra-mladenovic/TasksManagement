using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksManagement.Application.DataTransfer;
using TasksManagement.DataAccess;

namespace TasksManagement.Implementation.Validators
{
    public class UpsertUserValidator : AbstractValidator<UserDto>
    {
        public UpsertUserValidator(TasksManagementContext context)
        {
            RuleFor(x => x.Email).NotEmpty().Must(email => !context.Users.Any(g => g.Email == email)).WithMessage("Email is already in use!");
            RuleFor(x => x.Username).NotEmpty().Must(username => !context.Users.Any(g => g.Username == username)).WithMessage("Username must be unique!");
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(5);
        }
    }
}
