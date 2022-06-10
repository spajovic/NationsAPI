using AutoMapper;
using NationsApi.Application.Dto.Continets;
using NationsApi.Application.Dto.Countries;
using NationsApi.Application.Dto.CountryStats;
using NationsApi.Application.Dto.Language;
using NationsApi.Application.Dto.Regions;
using NationsApi.Application.Dto.Roles;
using NationsApi.Application.Dto.Users;
using NationsApi.Application.Mapper.Resolvers;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Mapper
{
    public class MapperProfile : Profile
    {
        private NationsContext context;
        public MapperProfile(NationsContext context)
        {
            this.context = context;

            // Continent
            CreateMap<AddContinentDto, Continent>();
            CreateMap<UpdateContinentDto, Continent>();
            CreateMap<Continent, GetContinentDto>();

            //Region
            CreateMap<AddRegionDto, Region>();
            CreateMap<UpdateRegionDto, Region>();
            CreateMap<Region, GetRegionDto>();

            //Roles
            CreateMap<AddRoleDto, Role>();
            CreateMap<UpdateRoleDto, Role>();
            CreateMap<Role, GetRoleDto>();

            //Users
            CreateMap<AddUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, GetUserDto>();

            //Countries
            CreateMap<AddCountryDto, Country>().ForMember(x => x.Languages, q => q.MapFrom(new LanguageIdsResolver(context)));
            CreateMap<UpdateCountryDto, Country>().ForMember(x => x.Languages, q => q.MapFrom(new LanguageIdsResolver(context)));
            CreateMap<Country,GetCountryDto>().ForMember(x => x.Languages, q => q.MapFrom(new LanguageNamesResolver()));

            //Languages
            CreateMap<AddLanguageDto, Language>();
            CreateMap<UpdateLanguageDto, Language>();
            CreateMap<Language, GetLanguageDto>().ForMember(x => x.Countries, q => q.MapFrom(new CountryNamesResolver()));

            //CountryStats
            CreateMap<AddCountryStatDto, CountryStat>();
            CreateMap<UpdateCountryStatDto, CountryStat>();
            CreateMap<RemoveCountryStatDto, CountryStat>();
            CreateMap<CountryStat, GetCountryStatDto>();
        }
    }
}
