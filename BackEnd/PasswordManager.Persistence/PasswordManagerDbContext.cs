using PasswordManager.Domain.Common;
using PasswordManager.Domain.Entities;
using PasswordManager.Domain.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Persistence
{
    public class PasswordManagerDbContext : DbContext
    {
        public PasswordManagerDbContext(DbContextOptions<PasswordManagerDbContext> options)
           : base(options)
        {
        }

        public DbSet<ServiceCredential> ServiceCredentials { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ServiceCredentialMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }

    }
}
