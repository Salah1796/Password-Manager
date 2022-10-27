using System;

namespace PasswordManager.Application.Models.ViewModels
{
    public class GetServiceCredentialByIdRespnseViewModel
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceURL { get; set; }
        public string AccountUsername { get; set; }
        public string AccountPassword { get; set; }
        public Guid UserId { get; set; }
    }
}
