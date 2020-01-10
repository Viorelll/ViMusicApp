using System;
using System.Collections.Generic;

namespace ViMusic.Domain.Entities
{
    public class Album 
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public int CreatedBy { get; set; }

        public string CoverUrl { get; set; }

        #region Links
        public virtual int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }

        #endregion
    }
}
