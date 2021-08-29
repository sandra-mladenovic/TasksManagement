﻿using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.Commands;
using TasksManagement.Application.DataTransfer;
using TasksManagement.Application.Searches;

namespace TasksManagement.Application.Queries
{
    public interface IGetProjectsQuery : IQuery<ProjectSearch, PagedResponse<ProjectDto>>
    {
    }
}
