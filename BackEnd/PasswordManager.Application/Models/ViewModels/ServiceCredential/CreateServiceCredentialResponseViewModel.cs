using System;

namespace PasswordManager.Application.Models.ViewModels
{
    public class CreateServiceCredentialResponseViewModel
    {
        public Guid Id { get; set; }
        public string AccountUsername { get; set; }
        public string AccountPassword { get; set; }
    }
}
