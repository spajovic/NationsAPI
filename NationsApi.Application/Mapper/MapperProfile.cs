using AutoMapper;
using NationsApi.Application.Dto.Continets;
using NationsApi.Application.Dto.Regions;
using NationsApi.Application.Dto.Roles;
using NationsApi.Application.Dto.Users;
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
        public MapperProfile()
        {
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
        }
    }
}
