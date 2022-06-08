using NationsApi.Application.Dto.Roles;
using NationsApi.Application.Interfaces;
using NationsApi.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Queries.Roles
{
    public interface IGetRolesQuery : IQuery<RoleSearch, IEnumerable<GetRoleDto>>
    {
    }
}
