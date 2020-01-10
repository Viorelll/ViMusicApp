using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ViMusic.Domain.Entities;

namespace ViMusic.Persistence.Configurations
{
    public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.Property(r => r.Name);

            builder.Property(r => r.Created);

            builder.Property(r => r.CreatedBy);

            #region Links

            builder.HasKey(r => r.Id);

            builder
                .HasMany(pl => pl.Songs)
                .WithOne(s => s.Playlist);

            #endregion
        }
    }
}
