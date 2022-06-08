using NationsApi.Application.Commands.Regions;
using NationsApi.Application.Exceptions;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.RegionCommands
{
    public class EfDeleteRegionCommand : BaseContext, IDeleteRegionCommand
    {
        public EfDeleteRegionCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => "Soft delte Region";

        public void Execute(int request)
        {
            Region region = context.Regions.Find(request);

            if (region == null)
            {
                throw new EntityNotFoundException(request, "Continents");
            }

            region.DeletedAt = DateTime.Now;

            context.Regions.Update(region);
            context.SaveChanges();
        }
    }
}
