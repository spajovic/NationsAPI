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
    public class UpdateContinentValidator : AbstractValidator<UpdateContinentDto>
    {
        private NationsContext _context;

        public UpdateContinentValidator(NationsContext context)
        {
            _context = context;

            RuleFor(x => x.Id).Must(x => ItemExists(x))
                .WithMessage("Provided continent id does not exist is databse.");

            RuleFor(x => x.Name).NotEmpty().MaximumLength(50)
                .WithMessage("Continent name is required, maximum number of characters allowed is 50.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name)
                    .Must((dto, c) => UniqueContinentName(dto))
                    .WithMessage("Provided Continent name already exists.");
                });
        }

        private bool ItemExists(int id)
        {
            return _context.Continents
                .Where(x => x.Id == id)
                .FirstOrDefault() != null;
        }

        private bool UniqueContinentName(UpdateContinentDto dto)
        {
            bool unique = _context.Continents
                .Where(x => x.Id != dto.Id && x.Name == dto.Name)
                .FirstOrDefault() == null;

            return unique;
        }
    }

    
}
