using FluentValidation;
using PasswordManager.Application.Features.ServiceCredential.Queries.GetById;

namespace PasswordManager.Application.Validation.ServiceCredential
{
    public class GetServiceCredentialByIdQueryValidator : AbstractValidator<GetServiceCredentialByIdQuery>
    {
        public GetServiceCredentialByIdQueryValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
