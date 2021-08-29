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
    public class UpdateStatusTypeCommand : IUpdateStatusTypeCommand
    {
        private readonly TasksManagementContext _context;
        private readonly UpsertStatusTypeValidator _validate;

        public UpdateStatusTypeCommand(TasksManagementContext context, UpsertStatusTypeValidator validate)
        {
            _context = context;
            _validate = validate;
        }

        public int Id => 21;

        public string Name => "Update StatusType";

        public void Execute(StatusTypeDto request)
        {
            var statusType = _context.StatusTypes.Find(request.Id);

            if (statusType == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(StatusType));
            }

            _validate.ValidateAndThrow(request);

            statusType.Name = request.Name;

            _context.SaveChanges();
        }
    }
}
