using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(temp => temp.Email)
           .NotEmpty().WithMessage("Email is Required")
           .EmailAddress().WithMessage("Should be a valid email address");

            RuleFor(temp => temp.Password)
                .NotEmpty().WithMessage("Password is Required");

            RuleFor(temp => temp.Gender)
               .IsInEnum().WithMessage("Invalid gender option")
               .NotNull().WithMessage("Gender is required");

            RuleFor(temp => temp.PersonName)
               .NotEmpty().WithMessage("Person Name is Required")
               .MaximumLength(50).WithMessage("Should be less than 50 letters");


        }
    }
}
