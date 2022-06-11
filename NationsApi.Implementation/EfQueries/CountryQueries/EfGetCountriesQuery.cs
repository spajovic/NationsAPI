using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NationsApi.Application.Dto.Countries;
using NationsApi.Application.Queries.Countries;
using NationsApi.Application.Searches;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfQueries.CountryQueries
{
    public class EfGetCountriesQuery : BaseQuery<Country>,IGetCountriesQuery
    {
        private IMapper _mapper;

        public EfGetCountriesQuery(NationsContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 25;

        public string Name => "Get Countries";

        public IEnumerable<GetCountryDto> Execute(CountrySearch search)
        {
            var query = context.Countries
                .Include(i => i.Region)
                .Include(i => i.User)
                .Include(i => i.Region.Continent)
                .Include(i => i.Languages)
                .Include(i => i.CountryStats)
                .Include(i => i.CountryFlags)
                .AsQueryable();

            BasicFilter(ref query, search);

            if (!String.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            if (!String.IsNullOrEmpty(search.UserName))
            {
                query = query.Where(x => x.User.FirstName.ToLower().Contains(search.UserName.ToLower()) 
                || x.User.LastName.ToLower().Contains(search.UserName.ToLower()));
            }
            if (!String.IsNullOrEmpty(search.RegionName))
            {
                query = query.Where(x => x.Region.Name.ToLower().Contains(search.RegionName.ToLower()));
            }
            if (!String.IsNullOrEmpty(search.ContinentName))
            {
                query = query.Where(x => x.Region.Continent.Name.ToLower().Contains(search.ContinentName.ToLower()));
            }
            if (!String.IsNullOrEmpty(search.CountryCode))
            {
                query = query.Where(x => x.CountryCode.ToLower().Contains(search.CountryCode.ToLower()));
            }

            return query.Select(x => _mapper.Map<Country, GetCountryDto>(x)).ToList();

        }
    }
}
