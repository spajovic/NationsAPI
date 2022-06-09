using NationsApi.Application.Commands.Languages;
using NationsApi.Application.Exceptions;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.EfCommands.LanguageCommands
{
    public class EfDeleteLanguageCommand : BaseContext, IDeleteLanguageCommand
    {
        public EfDeleteLanguageCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 28;

        public string Name => "Delete Language Command";

        public void Execute(int request)
        {
            Language language = context.Languages.Find(request);

            if (language == null)
            {
                throw new EntityNotFoundException(request, "Continents");
            }

            language.DeletedAt = DateTime.Now;

            context.Languages.Update(language);
            context.SaveChanges();
        }
    }
}
