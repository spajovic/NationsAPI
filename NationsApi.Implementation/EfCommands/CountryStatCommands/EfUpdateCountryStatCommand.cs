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
    public class EfUpdateCountryStatCommand : BaseContext, IUpdateCountryStatCommand
    {
        public EfUpdateCountryStatCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 32;

        public string Name => "Update Country Stat";

        public void Execute(CountryStat request)
        {
            CountryStat countryStat = context.CountryStats
                .Where(x => x.CountryId == request.CountryId && x.Year == request.Year)
                .FirstOrDefault();

            if (countryStat == null)
            {
                throw new EntityNotFoundException(request.CountryId, "Country Stat");
            }

            context.Entry(countryStat).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.UpdatedAt = DateTime.Now;

            var entity = context.CountryStats.Attach(request);

            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
