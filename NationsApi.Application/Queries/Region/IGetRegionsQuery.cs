using NationsApi.Application.Dto.Regions;
using NationsApi.Application.Interfaces;
using NationsApi.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Queries.Region
{
    public interface IGetRegionsQuery : IQuery<RegionSearch, IEnumerable<GetRegionDto>>
    {
    }
}
