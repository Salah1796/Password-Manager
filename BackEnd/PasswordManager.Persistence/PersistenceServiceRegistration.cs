using PasswordManager.Persistence;
using PasswordManager.Application.Contracts.Persistence;
using PasswordManager.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Application.Contracts.Persistence.IRepositories;
using PasswordManager.Application.Contracts.Persistence.IRepositories.Base;
using PasswordManager.Persistence.Repositories.Base;
namespace PasswordManager.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region AddDbContext
            services.AddDbContext<PasswordManagerDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString:PasswordManager"],
                b => b.MigrationsAssembly("PasswordManager.Persistence"));
            });
            #endregion

            #region Repositorys
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IServiceCredentialRepository, ServiceCredentialRepository>();


            #endregion

            #region UnitOfWork
            services.AddScoped<IUnitOfWorkAsync, UnitOfWorkAsync>();
            #endregion

            return services;    
        }
    }
}
