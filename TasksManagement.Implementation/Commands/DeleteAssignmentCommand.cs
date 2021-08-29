using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.Commands;
using TasksManagement.Application.Exceptions;
using TasksManagement.DataAccess;
using TasksManagement.Domain;

namespace TasksManagement.Implementation.Commands
{
    public class DeleteAssignmentCommand : IDeleteAssignmentCommand
    {
        private readonly TasksManagementContext _context;
        public DeleteAssignmentCommand(TasksManagementContext context)
        {
            _context = context;
        }
        public int Id => 13;

        public string Name => "Delete assignment";

        public void Execute(int request)
        {
            var assignment = _context.Assignments.Find(request);

            if (assignment == null)
            {
                throw new EntityNotFoundException(request, typeof(Assignment));
            }

            assignment.IsDeleted = true;
            assignment.IsActive = false;
            assignment.DeletedAt = DateTime.Now;

            _context.Assignments.Remove(assignment);
            _context.SaveChanges();
        }
    }
}
