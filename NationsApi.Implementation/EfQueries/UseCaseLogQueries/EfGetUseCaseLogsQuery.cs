using AutoMapper;
using NationsApi.Application.Dto.UseCaseLog;
using NationsApi.Application.Extensions;
using NationsApi.Application.Queries.UseCaseLog;
using NationsApi.Application.Searches;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfQueries.UseCaseLogQueries
{
    public class EfGetUseCaseLogsQuery : IGetUseCaseLogsQuery
    {
        private NationsContext _context;
        private IMapper _mapper;

        public EfGetUseCaseLogsQuery(NationsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 36;

        public string Name => "Get UseCase Logs";

        public IEnumerable<GetUseCaseLogDto> Execute(UseCaseLogSearch search)
        {
            var query = _context.UseCaseLog.AsQueryable();
            query.SkipItems(search.Page, search.ItemsPerPage);

            if (!String.IsNullOrEmpty(search.ActorName))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.ActorName.ToLower()));
            }
            if (!String.IsNullOrEmpty(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }
            if(search.DateTo.HasValue && search.DateFrom.HasValue)
            {
                if(search.DateTo < search.DateFrom)
                {
                    search.DateTo = search.DateFrom.Value;
                }
                query = query.Where(x => x.Date >= search.DateFrom && x.Date <= search.DateTo);
            }
            if(search.DateTo.HasValue)
            {
                query = query.Where(x => x.Date <= search.DateTo);
            }
            if(search.DateFrom.HasValue)
            {
                query = query.Where(x => x.Date >= search.DateFrom);
            }

            return query.Select(x => _mapper.Map<UseCaseLog, GetUseCaseLogDto>(x)).ToList();

        }
    }
}
