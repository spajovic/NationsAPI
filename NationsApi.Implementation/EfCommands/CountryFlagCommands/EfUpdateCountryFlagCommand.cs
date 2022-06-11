using AutoMapper;
using NationsApi.Application.Commands.CountryFlags;
using NationsApi.Application.Dto.CountryFlags;
using NationsApi.Application.FileUpload;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.CountryFlagCommands
{
    public class EfUpdateCountryFlagCommand : BaseContext, IUpdateCountryFlagCommand
    {
        private IMapper _mapper;
        public EfUpdateCountryFlagCommand(NationsContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 40;

        public string Name => "Update Country Flag";

        public void Execute(UpdateCountryFlagDto request)
        {
            Domain.CountryFlag countryFlag = context.CountryFlags
                .Where(x => x.Id == request.Id && x.CountryId == request.CountryId)
                .FirstOrDefault();

            context.Entry(countryFlag).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            countryFlag.UpdatedAt = DateTime.Now;
            countryFlag.FilePath = FlagImage.UpdateFlagImage(request.FilePath, countryFlag.FilePath);

            var entity = context.CountryFlags.Attach(countryFlag);

            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
