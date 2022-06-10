using FluentValidation;
using NationsApi.Application.Dto.CountryStats;
using NationsApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.Validators.CountryStat
{
    public class UpdateCountryStatValidator : AbstractValidator<UpdateCountryStatDto>
    {
        private NationsContext _context;

        public UpdateCountryStatValidator(NationsContext context)
        {
            _context = context;

            RuleFor(x => x.CountryId).NotEmpty()
                .WithMessage("COUNTRY ID is required.")
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.CountryId).Must(i => isCountryExsiting(i))
                        .WithMessage("Provided Country doesn't exist");
                    });

            RuleFor(x => x.Population).NotEmpty().WithMessage("Country population is required");
            RuleFor(x => x.Gdp).NotEmpty().WithMessage("Country GDP is required.");
            RuleFor(x => x.Year).NotEmpty()
                .WithMessage("YEAR is required.").DependentRules(() =>
                {
                    RuleFor(x => x.Year).Must(y => y < DateTime.Now.Year)
                    .WithMessage("Provided year must be in the past.");
                });
        }

        private bool isCountryExsiting(int id)
        {
            return _context.Countries.Find(id) != null;
        }
    }
}
