using NationsApi.Application.Commands.Regions;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.RegionCommands
{
    public class EfUpdateRegionCommand : BaseContext, IUpdateRegionCommand
    {
        public EfUpdateRegionCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 7;

        public string Name => "Update Region";

        public void Execute(Region request)
        {
            Region region = context.Regions.Find(request.Id);

            context.Entry(region).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.UpdatedAt = DateTime.Now;

            var entity = context.Regions.Attach(request);

            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
