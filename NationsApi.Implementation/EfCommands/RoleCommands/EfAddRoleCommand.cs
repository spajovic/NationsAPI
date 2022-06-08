using NationsApi.Application.Commands.Roles;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.RoleCommands
{
    public class EfAddRoleCommand : BaseContext, IAddRoleCommand
    {
        public EfAddRoleCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 11;

        public string Name => "Add new Role";

        public void Execute(Role request)
        {
            context.Add(request);
            context.SaveChanges();
        }
    }
}
