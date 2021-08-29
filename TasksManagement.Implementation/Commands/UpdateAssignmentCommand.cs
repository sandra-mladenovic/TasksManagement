using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksManagement.Application.Commands;
using TasksManagement.Application.DataTransfer;
using TasksManagement.Application.Exceptions;
using TasksManagement.DataAccess;
using TasksManagement.Domain;
using TasksManagement.Implementation.Validators;

namespace TasksManagement.Implementation.Commands
{
    public class UpdateAssignmentCommand : IUpdateAssignmentCommand
    {
        private readonly TasksManagementContext _context;
        private readonly UpsertAssignmentValidator _validator;
        public UpdateAssignmentCommand(TasksManagementContext context, UpsertAssignmentValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 15;

        public string Name => "Update assignment";

        public void Execute(AssignmentDto request)
        {
            var assignment = _context.Assignments.Find(request.Id);
            var developer = _context.Users.Where(x => x.RoleId == 3).Select(y => y.RoleId);
            if (assignment == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Assignment));
            }

            _validator.ValidateAndThrow(request);

            if (developer != null)
            {
                assignment.StatusTypeId = request.StatusTypeId;
            }

                assignment.Description = request.Description;
                assignment.Deadline = request.Deadline;
                assignment.UserId = request.UserId;
                assignment.StatusTypeId = request.StatusTypeId;
                assignment.ProjectId = assignment.ProjectId;

            _context.SaveChanges();
        }
    }
}
