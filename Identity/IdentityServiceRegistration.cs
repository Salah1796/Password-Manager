using AutoMapper.Configuration;
using Identity;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Application.Contracts.Identity;
using PasswordManager.Application.Contracts.Infrastructure;

namespace PasswordManager.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenService, JwtService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();


            return services;
        }
    }
}
