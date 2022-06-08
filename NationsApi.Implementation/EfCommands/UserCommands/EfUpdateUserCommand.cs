using NationsApi.Application.Commands.Users;
using NationsApi.Application.Exceptions;
using NationsApi.Application.Hash;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.UserCommands
{
    public class EfUpdateUserCommand : BaseContext, IUpdateUserCommand
    {
        public EfUpdateUserCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 17;

        public string Name => "Update User";

        public void Execute(User request)
        {
            User user = context.Users.Find(request.Id);

            if(user == null)
            {
                throw new EntityNotFoundException(request.Id, "User");
            }

            context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.UpdatedAt = DateTime.Now;
            request.Password = HashPassword.Encrypt(request.Password);

            var entity = context.Users.Attach(request);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
