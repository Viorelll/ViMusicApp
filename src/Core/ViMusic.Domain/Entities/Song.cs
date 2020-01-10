using System;

namespace ViMusic.Domain.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public int CreatedBy { get; set; }
        public string CoverUrl { get; set; }
        public string AudioUrl { get; set; }


        #region Links
        public virtual int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual Playlist Playlist { get; set; }
        public virtual Album Album { get; set; }
        #endregion

    }
}
