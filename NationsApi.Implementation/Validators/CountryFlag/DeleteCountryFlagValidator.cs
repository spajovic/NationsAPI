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
    public class DeleteCountryFlagValidator : AbstractValidator<DeleteCountryFlagDto>
    {
        private NationsContext _context;

        public DeleteCountryFlagValidator(NationsContext context)
        {
            _context = context;

            RuleFor(x => x.Id).NotEmpty().WithMessage("IMAGE ID is required").
                DependentRules(() =>
                {
                    RuleFor(x => x.Id).Must(x => isImageExisting(x))
                        .WithMessage("Provided IMAGE ID is not existing");
                });

            RuleFor(x => x.CountryId).NotEmpty()
                .WithMessage("COUNTRY ID is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.CountryId).Must(x => isCountryExisting(x))
                        .WithMessage("Provided COUNTRY ID does not have any images.");
                });


        }

        private bool isImageExisting(int id)
        {
            return _context.CountryFlags.Find(id) != null;
        }
        private bool isCountryExisting(int id)
        {
            return _context.CountryFlags.Find(id) != null;
        }
    }
}
