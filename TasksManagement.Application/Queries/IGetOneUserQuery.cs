using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.Commands;
using TasksManagement.Application.DataTransfer;

namespace TasksManagement.Application.Queries
{
    public interface IGetOneUserQuery : IQuery<int, UserDto>
    {
    }
}
