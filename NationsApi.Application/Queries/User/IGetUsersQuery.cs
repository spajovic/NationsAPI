using NationsApi.Application.Dto.Users;
using NationsApi.Application.Interfaces;
using NationsApi.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Queries.User
{
    public interface IGetUsersQuery : IQuery<UserSearch,IEnumerable<GetUserDto>>
    {
    }
}
