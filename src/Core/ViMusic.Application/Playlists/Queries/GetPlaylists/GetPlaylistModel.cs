using System;

namespace ViMusic.Application.Playlists.Queries.GetPlaylists
{
    public class GetPlaylistSoundModel
    {
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public int CreatedBy { get; set; }
        public string CoverUrl { get; set; }
    }
}
