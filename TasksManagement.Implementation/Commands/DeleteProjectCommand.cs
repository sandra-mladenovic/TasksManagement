using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.Commands;
using TasksManagement.Application.Exceptions;
using TasksManagement.DataAccess;
using TasksManagement.Domain;

namespace TasksManagement.Implementation.Commands
{
    public class DeleteProjectCommand : IDeleteAssignmentCommand
    {
        private readonly TasksManagementContext _context;
        public DeleteProjectCommand(TasksManagementContext context)
        {
            _context = context;
        }
        public int Id => 2;

        public string Name => "Delete Project";

        public void Execute(int request)
        {
            var project = _context.Projects.Find(request);

            if (project == null)
            {
                throw new EntityNotFoundException(request, typeof(Project));
            }

            //project.IsDeleted = true;
            //project.IsActive = false;
            //project.DeletedAt = DateTime.Now;

            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
    }
}
