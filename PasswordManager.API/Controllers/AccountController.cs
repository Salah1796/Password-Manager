using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Application.Common.Responses;
using PasswordManager.Application.Contracts.Identity;
using PasswordManager.Application.Models.ViewModels.Identity;

namespace PasswordManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IValidator<AuthenticationRequest> _authenticationRequestValidator;
        private readonly IValidator<RegistrationRequest> _registrationRequestValidator;

        public AccountController(IAuthenticationService authenticationService, IValidator<AuthenticationRequest> authenticationRequestValidator, IValidator<RegistrationRequest> registrationRequestValidator)
        {
            _authenticationService = authenticationService;
            _authenticationRequestValidator = authenticationRequestValidator;
            _registrationRequestValidator = registrationRequestValidator;
        }
        [Route("Register")]
        [HttpPost]
        public async Task<BaseResponse<RegistrationResponse>> Register(RegistrationRequest registrationRequest)
        {
            var validationResult = await _registrationRequestValidator.ValidateAsync(registrationRequest);
            if (!validationResult.IsValid)
            {
                throw new BadHttpRequestException(string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)));
            }
            return await _authenticationService.Register(registrationRequest);  
        }

        [Route("SignIn")]
        [HttpPost]
        public async Task<BaseResponse<AuthenticationResponse>> SignIn(AuthenticationRequest authenticationRequest)
        {
            var validationResult = await _authenticationRequestValidator.ValidateAsync(authenticationRequest);
            if (!validationResult.IsValid)
            {
                throw new BadHttpRequestException(string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            var result = await _authenticationService.SignIn(authenticationRequest);
            return result;
        }

    }
}
