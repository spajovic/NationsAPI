using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NationsApi.Application.Dto.Language;
using NationsApi.Application.Queries.Language;
using NationsApi.Application.Searches;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfQueries.LanguageQueries
{
    public class EfGetLanguagesQuery : BaseQuery<Language>, IGetLanguagesQuery
    {
        private IMapper _mapper;

        public EfGetLanguagesQuery(NationsContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 30;

        public string Name => "Get Languages";

        public IEnumerable<GetLanguageDto> Execute(LanguageSearch search)
        {
            var query = context.Languages
                .Include(i => i.Countries)
                .AsQueryable();

            BasicFilter(ref query, search);

            if (!String.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Select(x => _mapper.Map<Language, GetLanguageDto>(x)).ToList();
        }
    }
}
