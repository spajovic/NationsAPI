using NationsApi.Application.Commands.RoleCase;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.RoleCaseCommands
{
    public class EfAddRoleUseCaseCommand : BaseContext, IAddRoleUseCaseCommand
    {
        public EfAddRoleUseCaseCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 37;

        public string Name => "Add Role UseCase";

        public void Execute(RoleUseCase request)
        {
            context.Add(request);
            context.SaveChanges();
        }
    }
}
