using FluentValidation;
using NationsApi.Application.Dto.Countries;
using NationsApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.Validators.Country
{
    public class AddCountryValidator : AbstractValidator<AddCountryDto>
    {
        private NationsContext context;

        public AddCountryValidator(NationsContext context)
        {
            this.context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Provided country name has more then 50 characters.").
                DependentRules(() =>
                {
                    RuleFor(x => x.Name).Must(x => IsCountryNameUnique(x))
                    .WithMessage("Country name already exists in database.");
                });

            RuleFor(x => x.Area).NotEmpty()
                .WithMessage("Area property is required");

            RuleFor(x => x.NationalDay).Must(x => x < DateTime.Now)
                .WithMessage("NationDay property must be defined in the past.");

            RuleFor(x => x.CountryCode).NotEmpty()
                .WithMessage("Country Code is required.")
                .DependentRules(() =>
            {
                RuleFor(x => x.CountryCode).MinimumLength(2).MaximumLength(6)
                    .WithMessage("Country code can be in range of 2-6 characters")
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.CountryCode).Must(x => IsCountryCodeUnique(x))
                        .WithMessage("Country Code already exists in database.");
                    });
            });

            RuleFor(x => x.RegionId).NotEmpty()
                .WithMessage("Region ID is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.RegionId).Must(x => IsRegionExistant(x))
                    .WithMessage("Provided REGION Id is not exsisting in the database.");
                });

            RuleFor(x => x.UserId).NotEmpty()
                .WithMessage("User ID is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.UserId).Must(x => IsUserExistant(x))
                    .WithMessage("Provided user ID is not exsiting in the database");
                });
            
        }

        private bool IsCountryNameUnique(string dtoName)
        {
            return context.Countries.Where(x => x.Name == dtoName).FirstOrDefault() == null;
        }

        private bool IsRegionExistant(int id)
        {
            return context.Regions.Where(x => x.Id == id).FirstOrDefault() != null;
        }

        private bool IsUserExistant(int id)
        {
            return context.Users.Where(x => x.Id == id).FirstOrDefault() != null;
        }

        private bool IsCountryCodeUnique(string dtoCountryCode)
        {
            return context.Countries.Where(x => x.CountryCode == dtoCountryCode).FirstOrDefault() == null;
        }
    }
}
