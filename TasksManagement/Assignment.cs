using System;
using System.Collections.Generic;
using System.Text;

namespace TasksManagement.Domain
{
    public class Assignment : Entity
    {
        public decimal Progress { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public int StatusTypeId { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public virtual StatusType StatusType { get; set; }
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}
