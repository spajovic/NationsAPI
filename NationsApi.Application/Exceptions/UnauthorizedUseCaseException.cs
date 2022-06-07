using NationsApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        private IAppActor _actor;
        private IUseCase _useCase;

        public UnauthorizedUseCaseException(IAppActor actor, IUseCase useCase)
        {
            _actor = actor;
            _useCase = useCase;
        }

        public override string Message => $"Application user {_actor.Username} with an ID of: {_actor.Id} tried to execute {_useCase.Name}";
    }
}
