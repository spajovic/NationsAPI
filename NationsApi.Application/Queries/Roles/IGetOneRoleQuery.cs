using NationsApi.Application.Dto.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Queries.Roles
{
    public interface IGetOneRoleQuery : Interfaces.IQuery<int, GetRoleDto>
    {
    }
}
