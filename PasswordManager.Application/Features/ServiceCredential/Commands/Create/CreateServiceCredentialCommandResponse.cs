using PasswordManager.Application.Models.ViewModels;
using PasswordManager.Application.Common.Responses;

namespace PasswordManager.Application.Features.ServiceCredential.Commands.Create
{
    public class CreateServiceCredentialCommandResponse : BaseResponse<CreateServiceCredentialResponseViewModel>
    {
        public CreateServiceCredentialCommandResponse(): base()
        {

        }

    }
}