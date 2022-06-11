using NationsApi.Application.Commands.CountryFlags;
using NationsApi.Application.Exceptions;
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
    public class EfDeleteCountryFlagCommand : BaseContext, IDeleteCountryFlagCommand
    {
        public EfDeleteCountryFlagCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 41;

        public string Name => "Delete Country Flags";

        public void Execute(CountryFlag request)
        {
            CountryFlag countryFlag = context.CountryFlags
                .Where(x => x.Id == request.Id && x.CountryId == request.Id)
                .FirstOrDefault();

            if (countryFlag == null)
            {
                throw new EntityNotFoundException(request.Id, "Country Flag");
            }

            countryFlag.DeletedAt = DateTime.Now;
            FlagImage.RemoveFile(countryFlag.FilePath);

            context.CountryFlags.Update(countryFlag);
            context.SaveChanges();
        }
    }
}
