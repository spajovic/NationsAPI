using AutoMapper;
using NationsApi.Application.Dto.Continets;
using NationsApi.Application.Queries.Continent;
using NationsApi.Application.Searches;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfQueries.ContinentQueries
{
    public class EfGetContinentsQuery : BaseQuery<Continent>, IGetContinentsQuery
    {
        private IMapper _mapper;

        public EfGetContinentsQuery(NationsContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 5;

        public string Name => "Get All Continents";

        public IEnumerable<GetContinentDto> Execute(ContinentSearch search)
        {
            var query = context.Continents.AsQueryable();

            BasicFilter(ref query, search);

            if (!String.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Select(x => _mapper.Map<Continent, GetContinentDto>(x)).ToList();
        }
    }
}
