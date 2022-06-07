﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Interfaces
{
    public interface IAppActor
    {
        int Id { get; }
        string Username { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
