using PasswordManager.Application.Features.ServiceCredential.Commands.Update;
using FluentValidation;
using System;

namespace PasswordManager.Application.Validation.ServiceCredential
{
    public class UpdateServiceCredentialCommandValidator : AbstractValidator<UpdateServiceCredentialCommand>
    {
        public UpdateServiceCredentialCommandValidator()
        {
            RuleFor(p => p.Id)
              .NotNull().WithMessage("{PropertyName} is required.");

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
