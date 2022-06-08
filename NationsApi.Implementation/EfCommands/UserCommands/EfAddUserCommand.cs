using NationsApi.Application.Commands.Users;
using NationsApi.DataAccess;
using NationsApi.Domain;
using NationsApi.Application.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationsApi.Application.Dto.Email;
using NationsApi.Application.Email;

namespace NationsApi.Implementation.EfCommands.UserCommands
{
    public class EfAddUserCommand : BaseContext, IAddUserCommand
    {
        private IEmailSender _emailSender;
        public EfAddUserCommand(NationsContext context, IEmailSender emailSender) : base(context)
        {
            _emailSender = emailSender;
        }

        public int Id => 16;

        public string Name => "Create user";

        public void Execute(User request)
        {
            // Outdated
            request.Password = HashPassword.Encrypt(request.Password);

            context.Users.Add(request);
            context.SaveChanges();

            // Email sender
            SendEmailDto emailDto = new SendEmailDto
            {
                SendTo = request.Email,
                Subject = "Welcome to NATIONS APP",
                Content = "Welcome to our Nations app, here you can discover information about nations worldwide."
            };

            _emailSender.SendEmail(emailDto);

        }
    }
}
