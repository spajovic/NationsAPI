using AutoMapper;
using NationsApi.Application.Dto.Roles;
using NationsApi.Application.Queries.Roles;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfQueries.RoleQueries
{
    public class EfGetOneRoleQuery : BaseQuery<Role>, IGetOneRoleQuery
    {
        private IMapper _mapper;

        public EfGetOneRoleQuery(NationsContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 14;

        public string Name => "Get one Role";

        public GetRoleDto Execute(int search)
        {
            Role role = context.Roles.Find(search);
            if (role?.DeletedAt != null)
            {
                return null;
            }
            return _mapper.Map<Role, GetRoleDto>(role);
        }
    }
}
