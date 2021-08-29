using System;
using System.Collections.Generic;
using System.Text;

namespace TasksManagement.Application.DataTransfer
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class ReadProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ReadTasksDetailsDto> Tasks { get; set; } = new List<ReadTasksDetailsDto>();
    }

    public class ReadTasksDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
