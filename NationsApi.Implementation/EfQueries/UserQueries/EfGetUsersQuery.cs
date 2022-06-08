using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NationsApi.Application.Dto.Users;
using NationsApi.Application.Queries.User;
using NationsApi.Application.Searches;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfQueries.UserQueries
{
    public class EfGetUsersQuery : BaseQuery<User>, IGetUsersQuery
    {
        private IMapper _mapper;

        public EfGetUsersQuery(NationsContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 20;

        public string Name => "Get all Users";

        public IEnumerable<GetUserDto> Execute(UserSearch search)
        {
            var query = this.context.Users
                .Include(i => i.Role)
                .AsQueryable();

            BasicFilter(ref query, search);

            if (!String.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.Name.ToLower()));
            }
            if (!String.IsNullOrEmpty(search.Surname)){
                query = query.Where(x => x.LastName.ToLower().Contains(search.Surname.ToLower()));
            }
            if (!String.IsNullOrEmpty(search.Email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(search.Email.ToLower()));
            }
            if (!String.IsNullOrEmpty(search.RoleName))
            {
                query = query.Where(x => x.Role.Name.ToLower().Contains(search.RoleName.ToLower()));
            }
            if (search.RoleId > 0)
            {
                query = query.Where(x => x.RoleId == search.RoleId);
            }

            return query.Select(x => _mapper.Map<User, GetUserDto>(x)).ToList();
        }
    }
}
