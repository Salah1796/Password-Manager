using PasswordManager.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace PasswordManager.Application.Features.ServiceCredential.Queries.GetList
{
    public class GetServiceCredentialsListQuery : BaseFilter ,IRequest<GetServiceCredentialsListResponse>
    {
        #region Properties
        public string ServiceName { get; set; }
        public Guid CurrentUserId { get; set; }

        #endregion
    }
}
