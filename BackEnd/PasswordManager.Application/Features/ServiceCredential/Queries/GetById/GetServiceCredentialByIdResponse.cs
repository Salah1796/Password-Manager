using PasswordManager.Application.Common.Responses;
using PasswordManager.Application.Models.ViewModels;
using System.Collections.Generic;

namespace PasswordManager.Application.Features.ServiceCredential.Queries.GetById
{
    public class GetServiceCredentialByIdResponse : BaseResponse<GetServiceCredentialByIdRespnseViewModel>
    {
        public GetServiceCredentialByIdResponse(): base()
        {

        }

    }
}