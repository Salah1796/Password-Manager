using System;

namespace PasswordManager.Application.Models.ViewModels
{
    public class GetServiceCredentialsListRespnseViewModel
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceURL { get; set; }
        public string AccountUsername { get; set; }
        public string AccountPassword { get; set; }
    }
}
