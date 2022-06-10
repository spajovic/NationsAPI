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
    public class DeleteRoleUseCaseValidator : AbstractValidator<RoleUseCaseDto>
    {
        private NationsContext _context;

        public DeleteRoleUseCaseValidator(NationsContext context)
        {
            _context = context;

            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Role ID is required")
                .DependentRules(() =>
                {
                    RuleFor(x => x.RoleId).Must(x => isRoleExisting(x))
                        .WithMessage("Provided ROLE ID is not existing")
                            .DependentRules(() =>
                            {
                                RuleFor(x => x.RoleId).Must((dto,x) => isRoleCasePairAlreadyExisting(dto))
                                    .WithMessage("Provided combination of ROLE ID and USE CASE ID is not existing.");
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
