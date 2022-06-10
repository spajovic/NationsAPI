using NationsApi.Application.Dto.CountryStats;
using NationsApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Queries.CountryStat
{
    public interface IGetOneCountryStatQuery : IQuery<int,IEnumerable<GetCountryStatDto>>
    {
    }
}
