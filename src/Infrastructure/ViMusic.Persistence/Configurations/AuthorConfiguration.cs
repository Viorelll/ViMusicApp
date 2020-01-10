using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ViMusic.Domain.Entities;

namespace ViMusic.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(r => r.Name);

            #region Links

            builder.HasKey(a => a.Id);

            #endregion
        }
    }
}
