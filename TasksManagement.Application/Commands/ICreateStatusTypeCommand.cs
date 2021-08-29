using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.DataTransfer;

namespace TasksManagement.Application.Commands
{
    public interface ICreateStatusTypeCommand : ICommand<StatusTypeDto>
    {
    }
}
