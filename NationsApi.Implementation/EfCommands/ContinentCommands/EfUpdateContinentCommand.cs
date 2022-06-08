using NationsApi.Application.Commands.Continents;
using NationsApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.ContinentCommands
{
    public class EfUpdateContinentCommand : BaseContext, IUpdateContinentCommand
    {
        public EfUpdateContinentCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 2;

        public string Name => "Update Continent";

        public void Execute(Domain.Continent request)
        {
            Domain.Continent continent = context.Continents.Find(request.Id);

            context.Entry(continent).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.UpdatedAt = DateTime.Now;

            var entity = context.Continents.Attach(request);

            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

        }
    }
}
