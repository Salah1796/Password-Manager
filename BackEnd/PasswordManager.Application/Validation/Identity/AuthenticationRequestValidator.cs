using FluentValidation;
using PasswordManager.Application.Models.ViewModels.Identity;

namespace PasswordManager.Application.Validation.ServiceCredential
{
    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationRequestValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Password)
               .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
