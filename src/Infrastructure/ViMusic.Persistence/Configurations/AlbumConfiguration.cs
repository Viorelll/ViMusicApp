using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ViMusic.Domain.Entities;

namespace ViMusic.Persistence.Configurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.Property(r => r.Name);

            builder.Property(r => r.Created);

            builder.Property(r => r.CreatedBy);

            #region Links

            builder.HasKey(r => r.Id);

            builder
                .HasOne(r => r.Author);

            builder
                 .HasMany(a => a.Songs)
                 .WithOne(r => r.Album);

            #endregion
        }
    }
}
