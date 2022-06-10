using NationsApi.Application.Dto.UseCaseLog;
using NationsApi.Application.Interfaces;
using NationsApi.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Queries.UseCaseLog
{
    public interface IGetUseCaseLogsQuery : IQuery<UseCaseLogSearch, IEnumerable<GetUseCaseLogDto>>
    {
    }
}
