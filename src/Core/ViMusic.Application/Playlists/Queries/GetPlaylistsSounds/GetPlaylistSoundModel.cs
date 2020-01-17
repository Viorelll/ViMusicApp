using System;
using System.Collections.Generic;

namespace ViMusic.Application.Playlists.Queries.GetPlaylistsSounds
{
    public class GetPlaylistSoundModel
    {
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public string CoverUrl { get; set; }
        public ICollection<GetSongModel> Songs { get; set; } = new List<GetSongModel>();
    }
}
