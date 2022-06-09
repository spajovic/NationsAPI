using NationsApi.Application.Commands.Countries;
using NationsApi.Application.Exceptions;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NationsApi.Implementation.EfCommands.CountryCommands
{
    public class EfDeleteCountryCommand : BaseContext, IDeleteCountryCommand
    {
        public EfDeleteCountryCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 23;

        public string Name => "Delete Country";

        public void Execute(int request)
        {
            Country country = context.Countries.Find(request);

            if (country == null)
            {
                throw new EntityNotFoundException(request, "Continents");
            }

            country.DeletedAt = DateTime.Now;

            context.Countries.Update(country);
            context.SaveChanges();
        }
    }
}
