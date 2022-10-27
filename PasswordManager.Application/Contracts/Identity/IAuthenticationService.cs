using PasswordManager.Application.Common.Responses;
using PasswordManager.Application.Models.ViewModels.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<BaseResponse<RegistrationResponse>> Register(RegistrationRequest registrationRequest);
        Task<BaseResponse<AuthenticationResponse>> SignIn(AuthenticationRequest loginViewModel);
    }
}
