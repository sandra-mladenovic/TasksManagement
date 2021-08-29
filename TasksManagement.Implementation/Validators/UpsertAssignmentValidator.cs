using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksManagement.Application.DataTransfer;
using TasksManagement.DataAccess;

namespace TasksManagement.Implementation.Validators
{
    public class UpsertAssignmentValidator : AbstractValidator<AssignmentDto>
    {
        public UpsertAssignmentValidator(TasksManagementContext context)
        {
            RuleFor(x => x.Description)
              .NotEmpty()
              .WithMessage("Description is required parameter.");

            RuleFor(x => x.StatusTypeId)
              .NotEmpty()
              .WithMessage("Status is required parameter.");

            RuleFor(x => x.ProjectId)
              .NotEmpty()
              .WithMessage("Project is required parameter.");
        }
    }
}
