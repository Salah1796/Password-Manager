using System;

namespace PasswordManager.Application.Models.ViewModels.Identity
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
