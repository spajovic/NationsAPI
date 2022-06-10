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
    public class RemoveCountryStatValidator : AbstractValidator<RemoveCountryStatDto>
    {
        private NationsContext _context;

        public RemoveCountryStatValidator(NationsContext context)
        {
            _context = context;

            RuleFor(x => x.CountryId).NotEmpty()
                .WithMessage("COUNTRY ID is required.")
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.CountryId).Must(i => isCountryExsiting(i))
                        .WithMessage("Provided Country doesn't exist");
                    });

            RuleFor(x => x.Year).NotEmpty()
                .WithMessage("YEAR is required.").DependentRules(() =>
                {
                    RuleFor(x => x.Year).Must(y => y < DateTime.Now.Year)
                    .WithMessage("Provided year must be in the past.").DependentRules(() =>
                    {
                        RuleFor(x => x.Year).Must((dto,x) => isYearCountryExisting(dto))
                        .WithMessage("Provided year is not existing for selected country");
                    });
                });
        }
        private bool isCountryExsiting(int id)
        {
            return _context.Countries.Find(id) != null;
        }

        private bool isYearCountryExisting(RemoveCountryStatDto dto)
        {
            return _context.CountryStats.Where(x => x.CountryId == dto.CountryId && x.Year == dto.Year).FirstOrDefault() != null;
        }
    }
}
