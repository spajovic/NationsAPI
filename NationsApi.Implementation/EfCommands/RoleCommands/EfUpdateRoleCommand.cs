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
    public class EfUpdateRoleCommand : BaseContext, IUpdateRoleCommand
    {
        public EfUpdateRoleCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Update Role";

        public void Execute(Role request)
        {
            Role role = context.Roles.Find(request.Id);

            context.Entry(role).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.UpdatedAt = DateTime.Now;

            var entity = context.Roles.Attach(request);

            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
