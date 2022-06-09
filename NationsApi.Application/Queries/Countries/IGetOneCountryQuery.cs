using NationsApi.Application.Dto.Countries;
using NationsApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Queries.Countries
{
    public interface IGetOneCountryQuery : IQuery<int,GetCountryDto>
    {
    }
}
