using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.Queries;

namespace TasksManagement.Application.Searches
{
    public class AssignmentSearch : PagedSearch
    {
        public string Description { get; set; }
    }
}
