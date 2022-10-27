using PasswordManager.Application.Features.ServiceCredential.Queries.GetList;
using FluentValidation;

namespace PasswordManager.Application.Validation.ServiceCredential
{
    public class GetServiceCredentialsListQueryValidator : AbstractValidator<GetServiceCredentialsListQuery>
    {
        public GetServiceCredentialsListQueryValidator()
        {
        }
    }
}
