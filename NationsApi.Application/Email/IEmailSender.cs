using NationsApi.Application.Dto.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Email
{
    public interface IEmailSender
    {
        public void SendEmail(SendEmailDto dto);
    }
}
