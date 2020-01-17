using MediatR;
using ViMusic.Application.Models;

namespace ViMusic.Application.Playlists.Commands
{
    public class CreatePlaylistCommand : IRequest<int>
    {
        public string UserId { get; set; }
        public PlaylistModel Playlist { get; set; }
    }
}
