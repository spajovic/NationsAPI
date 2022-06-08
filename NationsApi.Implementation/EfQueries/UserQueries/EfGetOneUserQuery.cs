using AutoMapper;
using NationsApi.Application.Dto.Users;
using NationsApi.Application.Queries.User;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfQueries.UserQueries
{
    public class EfGetOneUserQuery : BaseQuery<User>, IGetOneUserQuery
    {
        private IMapper _mapper;

        public EfGetOneUserQuery(NationsContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 19;

        public string Name => "Get one User";

        public GetUserDto Execute(int search)
        {
            User user = context.Users.Find(search);
            if (user?.DeletedAt != null)
            {
                return null;
            }
            return _mapper.Map<User, GetUserDto>(user);
        }
    }
}
