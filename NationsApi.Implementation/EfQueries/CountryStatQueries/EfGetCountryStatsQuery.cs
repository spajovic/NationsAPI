using AutoMapper;
using NationsApi.Application.Dto.CountryStats;
using NationsApi.Application.Queries.CountryStat;
using NationsApi.Application.Searches;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfQueries.CountryStatQueries
{
    public class EfGetCountryStatsQuery : IGetCountryStatsQuery
    {
        private IMapper _mapper;
        private NationsContext _context;

        public EfGetCountryStatsQuery(IMapper mapper, NationsContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public int Id => 35;

        public string Name => "Get all Country Stats";

        public IEnumerable<GetCountryStatDto> Execute(CountryStatSearch search)
        {
            var query = _context.CountryStats.AsQueryable();

            if (search.OnlyActive == true)
            {
                if (search.OnlyActive == true)
                {
                    query = query.Where(x => x.DeletedAt == null);
                }
            }

            return query.Select(x => _mapper.Map<CountryStat, GetCountryStatDto>(x)).ToList();
        }
    }
}
