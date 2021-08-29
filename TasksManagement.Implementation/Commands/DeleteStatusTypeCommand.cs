using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.Commands;
using TasksManagement.Application.Exceptions;
using TasksManagement.DataAccess;
using TasksManagement.Domain;

namespace TasksManagement.Implementation.Commands
{
    public class DeleteStatusTypeCommand : IDeleteStatusTypeCommand
    {
        private readonly TasksManagementContext _context;

        public DeleteStatusTypeCommand(TasksManagementContext context)
        {
            _context = context;
        }
        public int Id => 23;

        public string Name => "Delete STatusType";

        public void Execute(int request)
        {
            var statusType = _context.StatusTypes.Find(request);

            if (statusType == null)
            {
                throw new EntityNotFoundException(request, typeof(StatusType));
            }

            statusType.IsDeleted = true;
            statusType.IsActive = false;
            statusType.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
