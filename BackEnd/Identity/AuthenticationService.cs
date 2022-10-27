using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using PasswordManager.Application.AutoMapper;
using PasswordManager.Application.Common.Responses;
using PasswordManager.Application.Contracts.Identity;
using PasswordManager.Application.Contracts.Persistence;
using PasswordManager.Application.Contracts.Persistence.IRepositories;
using PasswordManager.Application.Models.ViewModels.Identity;
using PasswordManager.Domain.Entities;
using System.Security.Claims;

namespace PasswordManager.Identity
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService _jwtService;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWorkAsync _unitOfWorkAsyn;
        public AuthenticationService(ITokenService jwtService, IUserRepository userRepository, IMapper mapper, IUnitOfWorkAsync unitOfWorkAsyn)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWorkAsyn = unitOfWorkAsyn;
        }
        

        public async Task<BaseResponse<AuthenticationResponse>> SignIn(AuthenticationRequest loginViewModel)
        {
            BaseResponse<AuthenticationResponse> loginResponseViewModel = new BaseResponse<AuthenticationResponse>();
            try
            {
                var existUser = await _userRepository.Get(u => u.UserName == loginViewModel.UserName)
                .SingleOrDefaultAsync();
                if (existUser != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(loginViewModel.Password, existUser.Password))
                    {
                        AuthenticationResponse response = _jwtService.CreateToken(existUser);
                        loginResponseViewModel.Data = response;
                    }
                    else
                    {
                        loginResponseViewModel.Success = false;
                        loginResponseViewModel.Message = "Invalid Username or passowrd ";
                    }
                }
                else
                {
                    loginResponseViewModel.Success = false;
                    loginResponseViewModel.Message = "Invalid Username or passowrd ";
                }

            }
            catch (Exception e)
            {

                loginResponseViewModel.Success = false;
                loginResponseViewModel.Message = "Invalid Username or passowrd ";
            }
            return loginResponseViewModel;
        }

        private  string HashPassword(string password)
        {
            int workFactor = 15;
            string salt = BCrypt.Net.BCrypt.GenerateSalt(workFactor);
            string loginpasswordHashed = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return loginpasswordHashed;
        }

        public async Task<BaseResponse<RegistrationResponse>>  Register (RegistrationRequest registrationRequest)
        {
            BaseResponse<RegistrationResponse> registrationResponse = new BaseResponse<RegistrationResponse>();
            var isUserExist = await _userRepository.Get()
                .FirstOrDefaultAsync(u => u.UserName == registrationRequest.UserName ||
                (!string.IsNullOrEmpty(u.Email) && u.Email == registrationRequest.Email));
            if (isUserExist != null)
            {
                registrationResponse.Success = false;
                if (registrationRequest.Email == registrationRequest.Email)
                    registrationResponse.Message = "Email already exists";
                if (registrationRequest.UserName == registrationRequest.UserName)
                    registrationResponse.Message += "UserName already exists";
            }
            else
            {
                var newUser = registrationRequest.ToModel(_mapper);
                newUser.Password = HashPassword(registrationRequest.Password);
                await _userRepository.AddAsync(newUser);
                await _unitOfWorkAsyn.CommitAsync();
                registrationResponse.Data = new RegistrationResponse() { UserId = newUser.Id };
            }
            return registrationResponse;
        }
    }
}