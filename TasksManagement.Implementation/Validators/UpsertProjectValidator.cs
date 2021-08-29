using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksManagement.Application.DataTransfer;
using TasksManagement.DataAccess;

namespace TasksManagement.Implementation.Validators
{
    public class UpsertProjectValidator : AbstractValidator<ProjectDto>
    {
        public UpsertProjectValidator(TasksManagementContext context)
        {
            RuleFor(x => x.Name)
              .NotEmpty()
              .WithMessage("Name is required parameter.")
              .Must(name => !context.Projects.Any(p => p.Name == name))
              .WithMessage(c => $"Project with the name of {c.Name} already exists in database.");

            RuleFor(x => x.Code)
              .NotEmpty()
              .WithMessage("Code is required parameter.")
              .Must(code => !context.Projects.Any(p => p.Code == code))
              .WithMessage(c => $"Project Code  {c.Code} already exists in database.");
        }
    }
}
