using MediatR;
using PasswordManager.Application.Features.ServiceCredential.Commands.Create;
using System;

namespace PasswordManager.Application.Features.ServiceCredential.Commands.Update
{
    public class UpdateServiceCredentialCommand : IRequest<UpdateServiceCredentialCommandResponse>
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceURL { get; set; }
        public string AccountUsername { get; set; }
        public string AccountPassword { get; set; }
        public Guid CurrentUserId { get; set; }

    }
}
