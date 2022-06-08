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
    public class UpdateRegionValidator : AbstractValidator<UpdateRegionDto>
    {
        private NationsContext _context;

        public UpdateRegionValidator(NationsContext context)
        {
            _context = context;

            RuleFor(x => x.Id).Must(x => ItemExists(x))
                .WithMessage("Provided region id does not exist is databse.");

            RuleFor(x => x.Name).NotEmpty().MaximumLength(50)
                .WithMessage("Region name is required, maximum number of characters allowed is 50.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name)
                    .Must((dto, c) => UniqueRegionName(dto))
                    .WithMessage("Provided Region name already exists.");
                });

            RuleFor(x => x.ContinentId)
                .Must(x => ContinentIdExists(x))
                .WithMessage("Provided continent ID is not existing");
        }

        private bool ItemExists(int id)
        {
            return _context.Regions
                .Where(x => x.Id == id)
                .FirstOrDefault() != null;
        }

        private bool UniqueRegionName(UpdateRegionDto dto)
        {
            bool unique = _context.Regions
                .Where(x => x.Id != dto.Id && x.Name == dto.Name)
                .FirstOrDefault() == null;

            return unique;
        }

        private bool ContinentIdExists(int id)
        {
            bool unique = _context.Continents.Where(x => x.Id == id).FirstOrDefault() != null;

            return unique;
        }
    }
}
