using System;

namespace ViMusic.Application.Playlists.Queries.GetPlaylists
{
    public class GetPlaylistSoundModel
    {
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public string CoverUrl { get; set; }
    }
}
