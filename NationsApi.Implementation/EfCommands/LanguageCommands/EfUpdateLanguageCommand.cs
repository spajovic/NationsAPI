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
    public class EfUpdateLanguageCommand : BaseContext, IUpdateLanguageCommand
    {
        public EfUpdateLanguageCommand(NationsContext context) : base(context)
        {
        }

        public int Id => 26;

        public string Name => "Update Language command";

        public void Execute(Language request)
        {
            Language language = context.Languages.Find(request.Id);

            if (language == null)
            {
                throw new EntityNotFoundException(request.Id, "Countries");
            }

            context.Entry(language).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.UpdatedAt = DateTime.Now;

            var entity = context.Languages.Attach(request);

            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
