using System;
using System.Collections.Generic;
using System.Text;

namespace TasksManagement.Domain
{
    public class StatusType : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; } = new HashSet<Assignment>();
    }
}
