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
    public class UpdateLanguageValidator : AbstractValidator<UpdateLanguageDto>
    {
        private NationsContext context;

        public UpdateLanguageValidator(NationsContext context)
        {
            this.context = context;

            RuleFor(x => x.Id).NotEmpty().WithMessage("Propertu ID is required").DependentRules(() =>
            {
                RuleFor(x => x.Id).Must(q => context.Languages.Where(l => l.Id == q).FirstOrDefault() != null)
                .WithMessage("Provided language does not exist");
            });

            RuleFor(x => x.Name).NotEmpty().WithMessage("Property NAME is required").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(x => context.Languages.Where(l => l.Name == x).FirstOrDefault() == null)
                .WithMessage("Provided Name already exists in database");
            });
        }
    }
}
