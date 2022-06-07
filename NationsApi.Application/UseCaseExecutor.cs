using NationsApi.Application.Exceptions;
using NationsApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application
{
    public class UseCaseExecutor
    {
        private readonly IAppActor _actor;
        private readonly IUseCaseLogger _logger;

        public UseCaseExecutor(IAppActor actor, IUseCaseLogger logger)
        {
            _actor = actor;
            _logger = logger;
        }

        public void ExecuteCommand<TRequest>(ICommand<TRequest> command, TRequest request)
        {
            _logger.Log(_actor, command, request);

            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(_actor, command);
            }

            command.Execute(request);
        }

        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch,TResult> query, TSearch search)
        {
            _logger.Log(_actor,query, search);

            if (!_actor.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedUseCaseException(_actor, query);
            }

            return query.Execute(search);
        }
    }
}
