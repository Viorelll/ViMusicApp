using Microsoft.EntityFrameworkCore;
using ViMusic.Domain.Entities;

namespace ViMusic.Persistence
{
    public class ViMusicDbContext : DbContext
    {
        public ViMusicDbContext(DbContextOptions<ViMusicDbContext> contextOptions) 
            : base(contextOptions)
        { }

        #region Enitites DbSets
        public DbSet<Album> Album { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Author> Author { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ViMusicDbContext).Assembly);
        }

    }
}
