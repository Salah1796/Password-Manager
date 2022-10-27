#region Using ...
using PasswordManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
#endregion
namespace PasswordManager.Domain.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        #region Methods
        public void Configure(EntityTypeBuilder<User> builder)
        {
            #region Configure Fields
            builder.Property(prop => prop.UserName).IsRequired();
            builder.Property(prop => prop.Password).IsRequired();
            builder.Property(prop => prop.Email).HasMaxLength(320);// RFC 
            builder.Property(prop => prop.Name).IsRequired().HasMaxLength(200);
            builder.HasIndex(p => p.UserName).IsUnique();
            builder.HasIndex(p => p.Email).IsUnique();
            #endregion
        }
        #endregion
    }
}
