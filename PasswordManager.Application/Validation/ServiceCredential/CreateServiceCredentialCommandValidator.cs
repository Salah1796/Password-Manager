using FluentValidation;
using PasswordManager.Application.Features.ServiceCredential.Commands.Create;

namespace PasswordManager.Application.Validation.ServiceCredential
{
    public class CreateServiceCredentialCommandValidator : AbstractValidator<CreateServiceCredentialCommand>
    {
        public CreateServiceCredentialCommandValidator()
        {
            RuleFor(p => p.AccountUsername)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.AccountPassword)
               .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.ServiceName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200);
            //.WithMessage("{PropertyName} must not exceed 11 characters.");
            RuleFor(p => p.ServiceURL)
           .MaximumLength(200);
        }
    }
}
