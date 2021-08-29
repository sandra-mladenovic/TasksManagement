using System;
using System.Collections.Generic;
using System.Text;

namespace TasksManagement.Application.Commands
{
    //CQRS - Command Query Responsibility Seggregation
    //ICommand and IQuery are representing one UseCase of the system 
    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }

    public interface IQuery<TSearch, TResult> : IUseCase
    {
        TResult Execute(TSearch search);
    }

    public interface IUseCase
    {
        int Id { get; }
        string Name { get; }
    }
}
