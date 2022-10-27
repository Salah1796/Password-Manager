using PasswordManager.Application.Contracts.Persistence.IRepositories.Base;
using PasswordManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PasswordManager.Application.Contracts.Persistence.IRepositories
{
    public interface IServiceCredentialRepository : IBaseRepositoryAsync<ServiceCredential, Guid>
    {
    }
}
