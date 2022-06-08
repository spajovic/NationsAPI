using NationsApi.Application.Dto.Continets;
using NationsApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Queries.Continent
{
    public interface IGetOneContinentQuery : IQuery<int,GetContinentDto>
    {    
    }
}
