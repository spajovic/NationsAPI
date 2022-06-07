using FluentValidation;
using NationsApi.Application.Dto.Continets;
using NationsApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.Validators.Continent
{
    public class AddContinentValidator : AbstractValidator<AddContinentDto>
    {
        private readonly NationsContext _context;

        public AddContinentValidator(NationsContext context)
        {
            _context = context;

            RuleFor(x => x.Name).
                NotEmpty()
                .MaximumLength(50)
                .WithMessage("'{PropertyValue}' mustn't be empty, and maximum amount of characters is 50").DependentRules(() =>
                {
                    RuleFor(x => x.Name).Must(x => _context.Continents.Where(c => c.Name == x).FirstOrDefault() == null)
                    .WithMessage("Continent with provided name already exists.");
                });
        }
    }
}
