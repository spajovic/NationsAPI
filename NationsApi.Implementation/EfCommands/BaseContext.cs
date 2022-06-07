using NationsApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands
{
    public abstract class BaseContext
    {
        protected NationsContext context { get; }

        protected BaseContext(NationsContext context)
        {
            this.context = context;
        }
    }
}
