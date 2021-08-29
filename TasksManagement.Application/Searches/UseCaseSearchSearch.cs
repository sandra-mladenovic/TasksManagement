using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.Queries;

namespace TasksManagement.Application.Searches
{
    public class UseCaseSearchSearch : PagedSearch
    {
        public string UseCaseName { get; set; }
        public string Actor { get; set; }
    }
}
