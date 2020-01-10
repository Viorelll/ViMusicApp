using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ViMusic.Domain.Entities;

namespace ViMusic.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        { 
            builder.Property(r => r.Password);

            builder.Property(r => r.Email);

            #region Links

            builder.HasKey(primaryKey => primaryKey.Id);

            builder
                 .HasMany(u => u.Playlists)
                 .WithOne(pl => pl.User)
                 .HasForeignKey(pl => pl.UserId);

            builder
                  .HasMany(u => u.Albums)
                  .WithOne(pl => pl.User)
                  .HasForeignKey(pl => pl.UserId);

            #endregion
        }
    }
}
