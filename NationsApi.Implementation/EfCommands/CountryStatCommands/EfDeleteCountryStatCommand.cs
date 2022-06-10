using NationsApi.Application.Commands.CountryStats;
using NationsApi.Application.Exceptions;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.CountryStatCommands
{
    public class EfDeleteCountryStatCommand : BaseContext, IDeleteCountryStatCommand
    {
        public EfDeleteCountryStatCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 33;

        public string Name => "Remove Country Stat";

        public void Execute(CountryStat request)
        {
            CountryStat countryStat = context.CountryStats
                .Where(x => x.CountryId == request.CountryId && x.Year == request.Year)
                .FirstOrDefault();

            if (countryStat == null)
            {
                throw new EntityNotFoundException(request.CountryId, "Country Stat");
            }

            countryStat.DeletedAt = DateTime.Now;

            context.CountryStats.Update(countryStat);
            context.SaveChanges();
        }
    }
}
