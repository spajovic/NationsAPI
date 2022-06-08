using AutoMapper;
using NationsApi.Application.Dto.Continets;
using NationsApi.Application.Queries.Continent;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfQueries.ContinentQueries
{
    public class EfGetOneContinentQuery : BaseQuery<Continent>, IGetOneContinentQuery
    {
        private IMapper _mapper;
        public EfGetOneContinentQuery(NationsContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 4;

        public string Name => "Get one continent";

        public GetContinentDto Execute(int search)
        {
            Continent continent = context.Continents.Find(search);
            
            if(continent?.DeletedAt != null)
            {
                return null;
            }

            return _mapper.Map<Continent, GetContinentDto>(continent);
        }
    }
}
