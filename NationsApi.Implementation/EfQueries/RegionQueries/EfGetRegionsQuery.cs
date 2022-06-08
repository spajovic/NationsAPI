using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NationsApi.Application.Dto.Regions;
using NationsApi.Application.Queries.Region;
using NationsApi.Application.Searches;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfQueries.RegionQueries
{
    public class EfGetRegionsQuery : BaseQuery<Region>, IGetRegionsQuery
    {
        private IMapper _mapper;
        public EfGetRegionsQuery(NationsContext context, IMapper mapper) : base(context)
        {
           _mapper = mapper;
        }

        public int Id => 10;

        public string Name => "Get all Regions";

        public IEnumerable<GetRegionDto> Execute(RegionSearch search)
        {
            var query = context.Regions
                .Include(i => i.Countries)
                .Include(i => i.Continent)
                .AsQueryable();

            BasicFilter(ref query, search);

            if (!String.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            if (!String.IsNullOrEmpty(search.CountryName))
            {
                query = query.Where(x => x.Countries.Any(y => y.Name.ToLower().Contains(search.CountryName.ToLower())));
            }
            if (!String.IsNullOrEmpty(search.ContinentName))
            {
                query = query.Where(x => x.Continent.Name.ToLower().Contains(search.ContinentName));
            }

            return query.Select(x => _mapper.Map<Region, GetRegionDto>(x)).ToList();
        }
    }
}
