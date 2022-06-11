using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NationsApi.Application.Dto.Countries;
using NationsApi.Application.Queries.Countries;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfQueries.CountryQueries
{
    public class EfGetOneCountryQuery : BaseQuery<Country>, IGetOneCountryQuery
    {
        private IMapper _mapper;

        public EfGetOneCountryQuery(NationsContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 24;

        public string Name => "Get One Query";

        public GetCountryDto Execute(int search)
        {
            Country country = context.Countries
                .Include(i => i.User)
                .Include(i => i.Region)
                .Include(i => i.Languages)
                .Include(i => i.CountryFlags)
                .FirstOrDefault(x => x.Id == search);

            if (country?.DeletedAt != null)
            {
                return null;
            }

            return _mapper.Map<Country, GetCountryDto>(country);
        }
    }
}
