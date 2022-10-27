using MediatR;
using PasswordManager.Application.Models.ViewModels;
using System;

namespace PasswordManager.Application.Features.ServiceCredential.Commands.Create
{
    public class CreateServiceCredentialCommand : IRequest<CreateServiceCredentialCommandResponse>
    {
        public string ServiceName { get; set; }
        public string ServiceURL { get; set; }
        public string AccountUsername { get; set; }
        public string AccountPassword { get; set; }
        public Guid CurrentUserId { get; set; }

    }
}
