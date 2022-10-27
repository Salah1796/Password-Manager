using MediatR;
using System;

namespace PasswordManager.Application.Features.ServiceCredential.Commands.Delete
{
    public class DeleteServiceCredentialCommand : IRequest<DeleteServiceCredentialCommandResponse>
    {
        public DeleteServiceCredentialCommand()
        {
            
        }
        public DeleteServiceCredentialCommand(Guid id, Guid CurrentUserId)
        {
            this.Id = id;  
            this.CurrentUserId = CurrentUserId;
        }
        public Guid Id { get; set; }
        public Guid CurrentUserId { get; set; }
    }
}
