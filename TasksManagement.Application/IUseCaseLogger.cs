using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Application.Commands;

namespace TasksManagement.Application
{
    public interface IUseCaseLogger //logging each action(UseCase) of a user to database
    {
        void Log(IUseCase userCase, IApplicationActor actor, object useCaseData);
    }
}
