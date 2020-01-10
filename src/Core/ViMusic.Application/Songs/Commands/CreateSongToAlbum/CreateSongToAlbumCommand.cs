using MediatR;
using ViMusic.Application.Models;

namespace ViMusic.Application.Songs.Commands.CreateSongToAlbum
{
    public class CreateSongToAlbumCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int AlbumId { get; set; }
        public SongModel Song { get; set; }
    }
}
