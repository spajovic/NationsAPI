using NationsApi.Application.Dto.Continets;
using NationsApi.Application.Interfaces;
using NationsApi.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Queries.Continent
{
    public interface IGetContinentsQuery : IQuery<ContinentSearch, IEnumerable<GetContinentDto>>
    {
    }
}
