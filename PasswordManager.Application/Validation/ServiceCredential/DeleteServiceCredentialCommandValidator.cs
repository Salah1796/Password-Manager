using PasswordManager.Application.Features.ServiceCredential.Commands.Delete;
using FluentValidation;
using System;

namespace PasswordManager.Application.Validation.ServiceCredential
{
    public class DeleteServiceCredentialCommandValidator : AbstractValidator<DeleteServiceCredentialCommand>
    {
        public DeleteServiceCredentialCommandValidator()
        {
            RuleFor(p => p.Id)
           .NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
