using System.Collections.Generic;

namespace ViMusic.Domain.Entities
{
    public class  User
    {
        public User()
        {
            Playlists = new HashSet<Playlist>();
            Albums = new HashSet<Album>();
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        #region Links
        public virtual ICollection<Playlist> Playlists { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        #endregion
    }
}
