using PasswordManager.Application.Contracts.Persistence;
using PasswordManager.Application.Contracts.Persistence.IRepositories;
using PasswordManager.Domain.Entities;
using PasswordManager.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordManager.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User,Guid>, IUserRepository
    {
        public UserRepository(PasswordManagerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
