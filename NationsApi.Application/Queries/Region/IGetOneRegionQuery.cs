using NationsApi.Application.Dto.Regions;
using NationsApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Queries.Region
{
    public interface IGetOneRegionQuery : IQuery<int, GetRegionDto>
    {
    }
}
