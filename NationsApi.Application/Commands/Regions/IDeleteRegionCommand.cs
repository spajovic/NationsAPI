using NationsApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Commands.Regions
{
    public interface IDeleteRegionCommand : ICommand<int>
    {
    }
}
