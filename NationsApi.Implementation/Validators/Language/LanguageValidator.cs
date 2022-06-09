using FluentValidation;
using NationsApi.Application.Dto.Language;
using NationsApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.Validators.Language
{
    public class LanguageValidator : AbstractValidator<AddLanguageDto>
    {
        private NationsContext _context;

        public LanguageValidator(NationsContext context)
        {
            _context = context;

            RuleFor(x => x.Name).NotEmpty().WithMessage("Property NAME is required").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(x => context.Languages.Where(l => l.Name == x).FirstOrDefault() == null)
                .WithMessage("Provided Name already exists in database");
            });
        }
    }
}
