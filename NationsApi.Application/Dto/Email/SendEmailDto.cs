﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Dto.Email
{
    public class SendEmailDto
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string SendTo { get; set; }
    }
}
