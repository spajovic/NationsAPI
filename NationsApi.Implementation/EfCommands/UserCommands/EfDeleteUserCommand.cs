using NationsApi.Application.Commands.Users;
using NationsApi.Application.Exceptions;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.UserCommands
{
    public class EfDeleteUserCommand : BaseContext, IDeleteUserCommand
    {
        public EfDeleteUserCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 18;

        public string Name => "Delete User";

        public void Execute(int request)
        {
            User user = context.Users.Find(request);

            if (user == null)
            {
                throw new EntityNotFoundException(request, "User");

            }

            user.DeletedAt = DateTime.Now;

            context.Users.Update(user);
            context.SaveChanges();
        }
    }
}
