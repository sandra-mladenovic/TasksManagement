using System;
using System.Collections.Generic;
using System.Text;

namespace TasksManagement.Application.Queries
{
    //T can be any type but that type should be referential
    public class PagedResponse<T> where T : class
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount => (int)Math.Ceiling((float)TotalCount / ItemsPerPage);
        public IEnumerable<T> Items { get; set; }
    }
}
