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
    public class EfAddRegionCommand : BaseContext, IAddRegionCommand
    {
        public EfAddRegionCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 6;

        public string Name => "Create new Region";

        public void Execute(Region request)
        {
            context.Add(request);
            context.SaveChanges();
        }
    }
}
