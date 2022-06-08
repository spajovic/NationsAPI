using NationsApi.Application.Commands.Continents;
using NationsApi.Application.Exceptions;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.ContinentCommands
{
    public class EfDeleteContinentCommand : BaseContext, IDeleteContinentCommand
    {
        public EfDeleteContinentCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Remove continent";

        public void Execute(int request)
        {
            Continent continent = context.Continents.Find(request);

            if(continent == null)
            {
                throw new EntityNotFoundException(request, "Continents");
            }

            continent.DeletedAt = DateTime.Now;

            context.Continents.Update(continent);
            context.SaveChanges();
        }
    }
}
