using NationsApi.Application.Dto.CountryStats;
using NationsApi.Application.Interfaces;
using NationsApi.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Queries.CountryStat
{
    public interface IGetCountryStatsQuery : IQuery<CountryStatSearch,IEnumerable<GetCountryStatDto>>
    {
    }
}
