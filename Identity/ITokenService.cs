using PasswordManager.Application.Models.ViewModels.Identity;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Identity
{
    public interface ITokenService
    {
        AuthenticationResponse CreateToken(User user);
        string getClaimValue(string token, string claimName);
    }
}