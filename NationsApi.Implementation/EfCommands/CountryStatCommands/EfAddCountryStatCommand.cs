using NationsApi.Application.Commands.CountryStats;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.CountryStatCommands
{
    public class EfAddCountryStatCommand : BaseContext, IAddCountryStatCommand
    {
        public EfAddCountryStatCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 31;

        public string Name => "Add Country Stat";

        public void Execute(CountryStat request)
        {
            context.Add(request);
            context.SaveChanges();
        }
    }
}
