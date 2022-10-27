using AutoMapper;
using PasswordManager.Application.Features.ServiceCredential.Commands.Create;
using PasswordManager.Application.Features.ServiceCredential.Commands.Update;
using PasswordManager.Application.Validation.ServiceCredential;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using PasswordManager.Application.Features.ServiceCredential.Queries.GetList;
using PasswordManager.Application.Features.ServiceCredential.Queries.GetById;
using PasswordManager.Application.Features.ServiceCredential.Commands.Delete;
using PasswordManager.Application.Models.ViewModels.Identity;

namespace PasswordManager.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IValidator<CreateServiceCredentialCommand>, CreateServiceCredentialCommandValidator>();
            services.AddScoped<IValidator<UpdateServiceCredentialCommand>, UpdateServiceCredentialCommandValidator>();
            services.AddScoped<IValidator<DeleteServiceCredentialCommand>, DeleteServiceCredentialCommandValidator>();

            services.AddScoped<IValidator<GetServiceCredentialsListQuery>, GetServiceCredentialsListQueryValidator>();
            services.AddScoped<IValidator<GetServiceCredentialByIdQuery>, GetServiceCredentialByIdQueryValidator>();

            services.AddScoped<IValidator<AuthenticationRequest>, AuthenticationRequestValidator>();
            services.AddScoped<IValidator<RegistrationRequest>, RegistrationRequestValidator>();


            return services;
        }
    }
}
