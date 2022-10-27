using FluentValidation;
using PasswordManager.Application.Models.ViewModels.Identity;

namespace PasswordManager.Application.Validation.ServiceCredential
{
    public class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
    {
        public RegistrationRequestValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Password)
               .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Name)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .MaximumLength(200);

            RuleFor(p => p.Email)
              .MaximumLength(320);
        }
    }
}
