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
    public class CreateAssignmentCommand : ICreateAssignmentCommand
    {
        private readonly TasksManagementContext _context;
        private readonly UpsertAssignmentValidator _validate;
        public CreateAssignmentCommand(TasksManagementContext context, UpsertAssignmentValidator validate)
        {
            _context = context;
            _validate = validate;
        }
        public int Id => 12;

        public string Name => "Create assignment";

        public void Execute(AssignmentDto request)
        {
            _validate.ValidateAndThrow(request); //ValidationException
            var assignment = new Assignment
            {
                Description = request.Description,
                ProjectId = request.ProjectId,
                StatusTypeId = request.StatusTypeId,
                Deadline = request.Deadline,
                UserId = request.UserId
            };

            _context.Assignments.Add(assignment);
            _context.SaveChanges();
        }
    }
}
