using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.DataTransfer;
using TasksManagement.Domain;

namespace TasksManagement.Application.Commands
{
    public interface IUpdateAssignmentCommand : ICommand<AssignmentDto>
    {
    }
}
