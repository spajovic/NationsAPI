using Microsoft.EntityFrameworkCore;
using NationsApi.Application.Commands.Countries;
using NationsApi.Application.Exceptions;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.CountryCommands
{
    public class EfUpdateCountryCommand : BaseContext, IUpdateCountryCommand
    {
        public EfUpdateCountryCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 22;

        public string Name => "Update country";

        public void Execute(Country request)
        {
            Country country = context.Countries.Find(request.Id);

            if (country == null)
            {
                throw new EntityNotFoundException(request.Id, "Countries");
            }

            request.UpdatedAt = DateTime.Now;

            request.CountryLanguages = request.Languages.Select(x => new CountryLanguage
            {
                Country = request,
                Language = x
            }).ToList();

            List<CountryLanguage> countryLanguages = context.CountryLanguages.Where(x => x.CountryId == request.Id).ToList();
            context.RemoveRange(countryLanguages);
            context.SaveChanges();

            context.Entry(country).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            var entity = context.Countries.Attach(request);

            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
