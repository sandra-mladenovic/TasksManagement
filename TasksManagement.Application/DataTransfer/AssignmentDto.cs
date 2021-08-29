using System;
using System.Collections.Generic;
using System.Text;

namespace TasksManagement.Application.DataTransfer
{
    public class AssignmentDto
    {
        public int Id { get; set; }
        public decimal Progress { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public int StatusTypeId { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}
