using NationsApi.Application.Commands.RoleCase;
using NationsApi.Application.Exceptions;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.RoleCaseCommands
{
    public class EfDeleteRoleUseCaseCommand : BaseContext, IDeleteRoleUseCaseCommand
    {
        public EfDeleteRoleUseCaseCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 38;

        public string Name => "Remove Role Use Case pair";

        public void Execute(RoleUseCase request)
        {
            RoleUseCase roleUseCase = context.RoleUseCases
                .Where(x => x.UseCaseId == request.UseCaseId && x.RoleId == request.RoleId)
                .FirstOrDefault();

            if(roleUseCase == null)
            {
                throw new EntityNotFoundException(request.RoleId, "RoleUseCase");
            }

            context.Remove(roleUseCase);
            context.SaveChanges();
        }
    }
}
