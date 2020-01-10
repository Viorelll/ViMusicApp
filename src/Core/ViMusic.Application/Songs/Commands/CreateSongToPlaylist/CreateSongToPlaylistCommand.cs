using MediatR;
using ViMusic.Application.Models;

namespace ViMusic.Application.Songs.Commands.CreateSongToPlaylist
{
    public class CreateSongToPlaylistCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int PlaylistId { get; set; }
        public int AuthorId { get; set; }
        public AuthorModel Author { get; set; }
        public SongModel Song { get; set; }
    }
}
