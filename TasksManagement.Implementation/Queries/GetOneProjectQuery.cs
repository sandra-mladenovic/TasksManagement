using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.DataTransfer;
using TasksManagement.Application.Exceptions;
using TasksManagement.Application.Queries;
using TasksManagement.DataAccess;
using TasksManagement.Domain;

namespace TasksManagement.Implementation.Queries
{
    public class GetOneProjectQuery : IGetOneProjectQuery
    {
        private readonly TasksManagementContext _context;

        public GetOneProjectQuery(TasksManagementContext context)
        {
            _context = context;
        }

        public int Id => 4;

        public string Name => "Get One Project";

        public ProjectDto Execute(int search)
        {
            var project = _context.Projects.Find(search);

            if (project == null) throw new EntityNotFoundException(search, typeof(Project));

            return new ProjectDto
            {
                Id = search,
                Name = project.Name,
                Code = project.Code,
            };
        }
    }
}
