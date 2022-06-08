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
    public class AddRoleValidator : AbstractValidator<AddRoleDto>
    {
        private NationsContext _context;

        public AddRoleValidator(NationsContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Name)
                .Must(x => IsRoleNameUnique(x))
                .WithMessage("Role with this name already exists.");
        }

        public bool IsRoleNameUnique(string value)
        {
            return _context.Roles.Where(x => x.Name == value).FirstOrDefault() == null;
        }
    }
}
