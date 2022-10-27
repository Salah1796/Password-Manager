﻿using PasswordManager.Application.Common.Responses;
using PasswordManager.Application.Models.ViewModels.Identity;
using Refit;
namespace UI.Data.ServiceCredential
{
    public interface IAccountService    
    {

        [Post("/Account/Register")]
        Task<BaseResponse<RegistrationResponse>> Register(RegistrationRequest registrationRequest);

        [Post("/Account/SignIn")]
        Task<BaseResponse<AuthenticationResponse>> SignIn(AuthenticationRequest authenticationRequest);
    }
}
