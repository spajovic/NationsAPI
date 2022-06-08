using FluentValidation;
using NationsApi.Application.Dto.Roles;
using NationsApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.Validators.Role
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleDto>
    {
        private NationsContext _context;

        public UpdateRoleValidator(NationsContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(x => ItemExists(x))
                .WithMessage("Provided Role ID does not exist.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(45)
                .WithMessage("Name is required, and maximum lentgh of characters is 45")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name)
                    .Must((dto, m) => IsRoleNameUnique(dto))
                    .WithMessage("Role with provided name already exists");
                });
        }

        public bool ItemExists(int id)
        {
            return _context.Roles
                .Where(x => x.Id == id)
                .FirstOrDefault() != null;
        }

        public bool IsRoleNameUnique(UpdateRoleDto dto)
        {
            return _context.Roles
                .Where(x => x.Name == dto.Name && x.Id != dto.Id)
                .FirstOrDefault() == null;
        }
    }
}
