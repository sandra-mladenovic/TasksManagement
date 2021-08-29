using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application;
using TasksManagement.Application.Commands;
using TasksManagement.DataAccess;
using TasksManagement.Domain;

namespace TasksManagement.Implementation.Logging
{
    public class LoggUseCaseDatabase : IUseCaseLogger //logging each action(UseCase) of a user to database
    {
        private readonly TasksManagementContext _context;

        public LoggUseCaseDatabase(TasksManagementContext context) => _context = context;

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name
            });

            _context.SaveChanges();
        }
    }
}
