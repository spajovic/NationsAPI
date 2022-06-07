using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Interfaces
{
    public interface IUseCaseLogger
    {
        void Log(IAppActor appActor, IUseCase useCase, object data);
    }
}
