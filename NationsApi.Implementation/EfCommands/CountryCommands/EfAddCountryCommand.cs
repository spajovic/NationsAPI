using NationsApi.Application.Commands.Countries;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.CountryCommands
{
    public class EfAddCountryCommand : BaseContext, IAddCountryCommand
    {
        public EfAddCountryCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 21;

        public string Name => "Add Country";

        public void Execute(Country request)
        {
            request.CountryLanguages = request.Languages.Select(x => new CountryLanguage
            {
                Country = request,
                Language = x
            }).ToList();

            context.Add(request);
            context.SaveChanges();
        }
    }
}
