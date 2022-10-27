using PasswordManager.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace PasswordManager.Application.Features.ServiceCredential.Queries.GetById
{
    public class GetServiceCredentialByIdQuery :IRequest<GetServiceCredentialByIdResponse>
    {
        public Guid Id { get; set; }
        public Guid CurrentUserId { get; set; }

    }
}
