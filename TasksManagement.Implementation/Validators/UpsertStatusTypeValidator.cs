using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksManagement.Application.DataTransfer;
using TasksManagement.DataAccess;

namespace TasksManagement.Implementation.Validators
{
    public class UpsertStatusTypeValidator : AbstractValidator<StatusTypeDto>
    {
        public UpsertStatusTypeValidator(TasksManagementContext context)
        {
            RuleFor(x => x.Name)
             .NotEmpty()
             .WithMessage("Name is required parameter.")
             .Must(name => !context.StatusTypes.Any(p => p.Name == name))
             .WithMessage(c => $"StatusType with the name of {c.Name} already exists in database.");
        }
    }
}
