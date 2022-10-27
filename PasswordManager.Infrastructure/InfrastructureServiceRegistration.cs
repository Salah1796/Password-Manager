using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Application.Contracts.Infrastructure;

namespace PasswordManager.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IEncryptionService, EncryptionService>();
            return services;
        }
    }
}
