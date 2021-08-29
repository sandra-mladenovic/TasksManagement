using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.Queries;

namespace TasksManagement.Application.Searches
{
    public class StatusTypeSearch : PagedSearch
    {
        public string Name { get; set; }
    }
}
