using FluentValidation;
using NationsApi.Application.Dto.Regions;
using NationsApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.Validators.Region
{
    public class AddRegionValidator : AbstractValidator<AddRegionDto>
    {
        private readonly NationsContext _context;

        public AddRegionValidator(NationsContext context)
        {
            _context = context;

            RuleFor(x => x.Name).NotEmpty()
                .MaximumLength(100).WithMessage("Region name is required, maximum characters allowed is 100")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name).Must(q => _context.Regions.Where(c => c.Name == q).FirstOrDefault() == null).
                    WithMessage("Provided Name already exists in database");
                });

            RuleFor(x => x.ContinentId).Must(s => _context.Continents.Where(c => c.Id == s).FirstOrDefault() != null)
                .WithMessage("Provided Continent ID is not existing");     
        }
    }
}
