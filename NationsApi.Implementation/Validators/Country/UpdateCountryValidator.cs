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
    public class UpdateCountryValidator : AbstractValidator<UpdateCountryDto>
    {
        private NationsContext context;

        public UpdateCountryValidator(NationsContext context)
        {
            this.context = context;

            RuleFor(x => x.Id).NotEmpty()
                .WithMessage("Country Id is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id).Must(x => IsCountryExisting(x))
                    .WithMessage("Country is not existing");
                });
                

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Provided country name has more then 50 characters.").
                DependentRules(() =>
                {
                    RuleFor(x => x.Name).Must((dto,x) => IsCountryNameUnique(dto))
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
                            RuleFor(x => x.CountryCode).Must((dto,x) => IsCountryCodeUnique(dto))
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

            RuleForEach(x => x.LanguageIds).ChildRules(id =>
            {
                id.RuleFor(x => x).Must(x => LanguageExists(x))
                .WithMessage("Provided id of Language is not valid.");
            });
        }

        private bool IsCountryExisting(int dtoId)
        {
            return context.Countries.Where(x => x.Id == dtoId && x.DeletedAt == null).FirstOrDefault() != null;
        }
        private bool IsCountryNameUnique(UpdateCountryDto dto)
        {
            return context.Countries.Where(x => x.Name == dto.Name && x.Id != dto.Id).FirstOrDefault() == null;
        }

        private bool IsRegionExistant(int id)
        {
            return context.Regions.Where(x => x.Id == id).FirstOrDefault() != null;
        }

        private bool IsUserExistant(int id)
        {
            return context.Users.Where(x => x.Id == id).FirstOrDefault() != null;
        }

        private bool IsCountryCodeUnique(UpdateCountryDto dto)
        {
            return context.Countries.Where(x => x.CountryCode == dto.CountryCode && x.Id != dto.Id).FirstOrDefault() == null;
        }

        private bool LanguageExists(int id)
        {
            return context.Languages.Find(id) != null;
        }
    }
}
