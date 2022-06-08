using NationsApi.Application.Commands.Roles;
using NationsApi.Application.Exceptions;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.RoleCommands
{
    public class EfDeleteRoleCommand : BaseContext, IDeleteRoleCommand
    {
        public EfDeleteRoleCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 13;

        public string Name => "Remove Role";

        public void Execute(int request)
        {
            Role role = context.Roles.Find(request);

            if (role == null)
            {
                throw new EntityNotFoundException(request, "Role");

            }

            role.DeletedAt = DateTime.Now;

            context.Roles.Update(role);
            context.SaveChanges();
        }
    }
}
