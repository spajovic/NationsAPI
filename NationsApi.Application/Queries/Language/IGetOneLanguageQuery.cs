using NationsApi.Application.Dto.Language;
using NationsApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Queries.Language
{
    public interface IGetOneLanguageQuery : IQuery<int,GetLanguageDto>
    {
    }
}
