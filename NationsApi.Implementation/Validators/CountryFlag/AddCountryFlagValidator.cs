using FluentValidation;
using NationsApi.Application.Dto.CountryFlags;
using NationsApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.Validators.CountryFlag
{
    public class AddCountryFlagValidator : AbstractValidator<AddCountryFlagDto>
    {
        private NationsContext _context;

        private const int maxSize = 2;
        private const int maxSizeMB = 2 * 1024 * 1024;

        public AddCountryFlagValidator(NationsContext context)
        {
            _context = context;

            RuleFor(x => x.CountryId).NotEmpty()
                .WithMessage("COUNTRY ID is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.CountryId).Must(x => isCountryExisting(x))
                        .WithMessage("Provided COUNTRY ID is not existing.");
                });

            RuleFor(x => x.FilePath).NotEmpty().WithMessage("FLAG IMAGE is required")
                 .DependentRules(() =>
                 {
                     RuleFor(x => x.FilePath.Length).LessThanOrEqualTo(maxSizeMB)
                        .WithMessage("Provided FILE is too large");

                     RuleFor(x => x.FilePath.ContentType)
                        .Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                        .WithMessage("Allowed FILE FORMATS are .jpeg .jpg and .png");
                 });

        }

        private bool isCountryExisting(int id)
        {
            return _context.Countries.Find(id) != null;
        }
    }
}
