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
    public class CreateProjectCommand : ICreateProjectCommand
    {
        private readonly TasksManagementContext _context;
        private readonly UpsertProjectValidator _validate;
        public CreateProjectCommand(TasksManagementContext context, UpsertProjectValidator validate)
        {
            _context = context;
            _validate = validate;
        }

        public int Id => 1;

        public string Name => "Create new Project";

        public void Execute(ProjectDto request)
        {

            _validate.ValidateAndThrow(request); //ValidationException
            var project = new Project
            {
                Name = request.Name,
                Code = request.Code
            };

            _context.Projects.Add(project);
            _context.SaveChanges();
        }
    }
}
