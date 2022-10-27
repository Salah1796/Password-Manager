using PasswordManager.Application.Common.Responses;
using PasswordManager.Application.Models.ViewModels;
using System.Collections.Generic;

namespace PasswordManager.Application.Features.ServiceCredential.Queries.GetList
{
    public class GetServiceCredentialsListResponse : BasePaginatedResponse<List<GetServiceCredentialsListRespnseViewModel>>
    {
        public GetServiceCredentialsListResponse(): base()
        {

        }

    }
}