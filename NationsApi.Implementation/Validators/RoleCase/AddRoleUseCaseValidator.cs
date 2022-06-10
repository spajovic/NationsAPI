using FluentValidation;
using NationsApi.Application.Dto.RoleCase;
using NationsApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.Validators.RoleCase
{
    public class AddRoleUseCaseValidator : AbstractValidator<RoleUseCaseDto>
    {
        private NationsContext _context;

        public AddRoleUseCaseValidator(NationsContext context)
        {
            _context = context;

            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Role ID is reuired")
                .DependentRules(() =>
            {
                RuleFor(x => x.RoleId).Must(x => isRoleExisting(x)).WithMessage("Provided ROLE ID is not existing")
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.UseCaseId).NotEmpty().WithMessage("UseCase ID is required.")
                            .DependentRules(() =>
                            {
                                RuleFor(x => x.UseCaseId).Must((dto, x) => !isRoleCasePairAlreadyExisting(dto))
                                    .WithMessage("Pair of RoleID and UseCase ID already exists");
                            });
                    });
            });

        }

        private bool isRoleExisting(int id)
        {
            return _context.Roles.Where(r => r.Id == id).FirstOrDefault() != null;
        }
        private bool isRoleCasePairAlreadyExisting(RoleUseCaseDto dto)
        {
            return _context.RoleUseCases.FirstOrDefault(x => x.RoleId == dto.RoleId && x.UseCaseId == dto.UseCaseId) != null;
        }
    }
}
