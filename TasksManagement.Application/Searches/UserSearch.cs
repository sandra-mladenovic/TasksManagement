using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.Queries;

namespace TasksManagement.Application.Searches
{
    public class UserSearch : PagedSearch
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
    }
}
