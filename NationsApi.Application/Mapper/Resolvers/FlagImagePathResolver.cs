using AutoMapper;
using NationsApi.Application.Dto.Countries;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Mapper.Resolvers
{
    public class FlagImagePathResolver : IValueResolver<Country, GetCountryDto, List<string>>
    {
        public List<string> Resolve(Country source, GetCountryDto destination, List<string> destMember, ResolutionContext context)
        {
            return source.CountryFlags.Select(x => x.FilePath).ToList();
        }
    }
}
