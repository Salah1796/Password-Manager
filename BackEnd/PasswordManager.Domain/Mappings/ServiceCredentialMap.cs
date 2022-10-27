#region Using ...
using PasswordManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
#endregion
namespace PasswordManager.Domain.Mappings
{
    public class ServiceCredentialMap : IEntityTypeConfiguration<ServiceCredential>
    {
        #region Methods
        public void Configure(EntityTypeBuilder<ServiceCredential> builder)
        {
            #region Configure Fields
            builder.Property(prop => prop.AccountUsername).IsRequired();
            builder.Property(prop => prop.AccountPassword).IsRequired();
            builder.Property(prop => prop.UserId).IsRequired();
            builder.Property(prop => prop.ServiceName).IsRequired().HasMaxLength(200);
            builder.Property(prop => prop.ServiceURL).HasMaxLength(200);
            builder.HasIndex(p => p.ServiceName);
            #endregion
            
        }
        #endregion
    }
}
