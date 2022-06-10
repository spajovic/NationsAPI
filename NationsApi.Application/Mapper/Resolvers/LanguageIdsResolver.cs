using AutoMapper;
using NationsApi.Application.Dto.Countries;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Mapper.Resolvers
{
    public class LanguageIdsResolver : IValueResolver<AddCountryDto, Country, ICollection<Language>>
    {
        private NationsContext _context;

        public LanguageIdsResolver(NationsContext context)
        {
            _context = context;
        }

        public ICollection<Language> Resolve(AddCountryDto source, Country destination, ICollection<Language> destMember, ResolutionContext context)
        {
            return source.LanguageIds.Select(x => _context.Languages.Find(x)).ToList();
        }
    }
}
