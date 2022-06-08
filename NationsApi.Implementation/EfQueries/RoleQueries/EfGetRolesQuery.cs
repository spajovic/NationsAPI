using AutoMapper;
using NationsApi.Application.Dto.Roles;
using NationsApi.Application.Queries.Roles;
using NationsApi.Application.Searches;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfQueries.RoleQueries
{
    public class EfGetRolesQuery : BaseQuery<Role>, IGetRolesQuery
    {
        private IMapper _mapper;

        public EfGetRolesQuery(NationsContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 15;

        public string Name => "Get all roles";

        public IEnumerable<GetRoleDto> Execute(RoleSearch search)
        {
            var query = this.context.Roles.AsQueryable();

            BasicFilter(ref query, search);

            if (!String.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

            }

            return query.Select(x => _mapper.Map<Role, GetRoleDto>(x)).ToList();
        }
    }
}
