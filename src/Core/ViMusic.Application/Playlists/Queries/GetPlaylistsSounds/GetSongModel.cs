using System;

namespace ViMusic.Application.Playlists.Queries.GetPlaylistsSounds
{
    public class GetSongModel
    {
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public int CreatedBy { get; set; }
        public string CoverUrl { get; set; }
        public string AudioUrl { get; set; }
        public string AuthorName { get; set; }
    }
}