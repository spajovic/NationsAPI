using AutoMapper;
using NationsApi.Application.Dto.Language;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Mapper.Resolvers
{
    public class CountryNamesResolver : IValueResolver<Language, GetLanguageDto, List<string>>
    {
        public List<string> Resolve(Language source, GetLanguageDto destination, List<string> destMember, ResolutionContext context)
        {
            return source.Countries.Select(x => x.Name).ToList();
        }
    }
}
