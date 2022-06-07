using NationsApi.Application.Commands.Continents;
using NationsApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.Continent
{
    public class EfAddContinentCommand : BaseContext, IAddContinentCommand
    {
        public EfAddContinentCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 1;

        public string Name => "Add new Continent";

        public void Execute(Domain.Continent request)
        {
            context.Add(request);
            context.SaveChanges();
        }
    }
}
