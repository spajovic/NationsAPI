using AutoMapper;
using NationsApi.Application.Dto.CountryStats;
using NationsApi.Application.Queries.CountryStat;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfQueries.CountryStatQueries
{
    public class EfGetOneCountryStatQuery : IGetOneCountryStatQuery
    {
        private IMapper _mapper;
        private NationsContext _context;
        public EfGetOneCountryStatQuery(NationsContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public int Id => 34;

        public string Name => "Get One Country Stats";

        public IEnumerable<GetCountryStatDto> Execute(int search)
        {
            var countryStats = _context.CountryStats
                .Where(x => x.CountryId == search && x.DeletedAt != null)
                .AsQueryable();

            if (countryStats == null)
            {
                return null;
            }

            return countryStats.Select(x => _mapper.Map<CountryStat, GetCountryStatDto>(x)).ToList();
        }
    }
}
