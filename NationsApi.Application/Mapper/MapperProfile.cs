using AutoMapper;
using NationsApi.Application.Dto.Continets;
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
        }
    }
}
