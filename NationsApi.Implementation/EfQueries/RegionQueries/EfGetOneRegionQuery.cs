using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NationsApi.Application.Dto.Regions;
using NationsApi.Application.Queries.Region;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfQueries.RegionQueries
{
    public class EfGetOneRegionQuery : BaseQuery<Region>, IGetOneRegionQuery
    {
        private IMapper _mapper;

        public EfGetOneRegionQuery(NationsContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 9;

        public string Name => "Get One Region";

        public GetRegionDto Execute(int search)
        {
            Region region = context.Regions
                .Include(i => i.Countries)
                .Include(i => i.Continent)
                .FirstOrDefault(x => x.Id == search);

            if (region?.DeletedAt != null)
            {
                return null;
            }

            return _mapper.Map<Region, GetRegionDto>(region);
        }
    }
}
