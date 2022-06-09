using NationsApi.Application.Commands.Languages;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.LanguageCommands
{
    public class EfAddLanguageCommand : BaseContext, IAddLanguageCommand
    {
        public EfAddLanguageCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 26;

        public string Name => "Add Language";

        public void Execute(Language request)
        {
            context.Add(request);
            context.SaveChanges();
        }
    }
}
