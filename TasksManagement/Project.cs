using System;
using System.Collections.Generic;
using System.Text;

namespace TasksManagement.Domain
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
