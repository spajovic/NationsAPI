using AutoMapper;
using NationsApi.Application.Dto.Language;
using NationsApi.Application.Queries.Language;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfQueries.LanguageQueries
{
    public class EfGetOneLanguageQuery : BaseQuery<Language>, IGetOneLanguageQuery
    {
        private IMapper _mapper;

        public EfGetOneLanguageQuery(NationsContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 29;

        public string Name => "Get one language";

        public GetLanguageDto Execute(int search)
        {
            Language language = context.Languages.Find(search);

            if (language?.DeletedAt != null)
            {
                return null;
            }

            return _mapper.Map<Language, GetLanguageDto>(language);
        }
    }
}
