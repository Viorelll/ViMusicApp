using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ViMusic.Domain.Entities;

namespace ViMusic.Persistence.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.Property(r => r.Name);

            builder.Property(r => r.Created);

            builder.Property(r => r.CreatedBy);


            #region Links

            builder.HasKey(r => r.Id);

            builder
                .HasOne(r => r.Author)
                .WithOne(r => r.Song)
                .HasForeignKey<Song>(fk => fk.AuthorId);

            #endregion
        }
    }
}
