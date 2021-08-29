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
    public class UpdateProjectCommand : IUpdateProjectCommand
    {
        private readonly TasksManagementContext _context;
        private readonly UpsertProjectValidator _validator;
        public UpdateProjectCommand(TasksManagementContext context, UpsertProjectValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 5;

        public string Name => "Update Project";

        public void Execute(ProjectDto request)
        {
            var project = _context.Projects.Find(request.Id);

            if (project == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Project));
            }

            _validator.ValidateAndThrow(request);

            project.Name = request.Name;
            project.Code = request.Code;

            _context.SaveChanges();
        }

        public void Execute(Assignment request)
        {
            throw new NotImplementedException();
        }
    }
}
