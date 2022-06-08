using FluentValidation;
using NationsApi.Application.Dto.Users;
using NationsApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.Validators.Users
{
    public class AddUserValidator : AbstractValidator<AddUserDto>
    {
        protected NationsContext _context;

        public AddUserValidator(NationsContext context)
        {
            _context = context;
            RuleFor(x => x.FirstName)
                .MaximumLength(45)
                .NotEmpty()
                .WithMessage("Maximum length of first name is 45 characters.");

            RuleFor(x => x.LastName)
                .MaximumLength(50)
                .NotEmpty()
                .WithMessage("Maximum length of Last Name is 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(x => !IsEmailAlreadyTaken(x))
                .WithMessage("Provided Email is already taken");



            RuleFor(x => x.Password)
                .MinimumLength(8)
                .NotEmpty()
                .WithMessage("Minimum length of Password is 8 characters");

            RuleFor(x => x.RoleId)
                .Must(x => RoleExists(x))
                .WithMessage("Provided Role ID does not exist.");
        }

        public bool RoleExists(int value)
        {
            return _context.Roles.Where(x => x.Id == value).FirstOrDefault() != null;
        }

        private bool IsEmailAlreadyTaken(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email) != null;
        }
    }
}
