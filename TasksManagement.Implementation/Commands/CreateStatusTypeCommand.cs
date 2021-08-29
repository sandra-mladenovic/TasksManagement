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
    public class CreateStatusTypeCommand : ICreateStatusTypeCommand
    {
        private readonly TasksManagementContext _context;
        private readonly UpsertStatusTypeValidator _validate;
        public CreateStatusTypeCommand(TasksManagementContext context, UpsertStatusTypeValidator validate)
        {
            _context = context;
            _validate = validate;
        }

        public int Id => 19;

        public string Name => "Create StatusType";

        public void Execute(StatusTypeDto request)
        {
            _validate.ValidateAndThrow(request); //ValidationException
            var statusType = new StatusType
            {
                Name = request.Name
            };

            _context.StatusTypes.Add(statusType);
            _context.SaveChanges();
        }
    }
}
