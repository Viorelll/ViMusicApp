using MediatR;
using ViMusic.Application.Models;

namespace ViMusic.Application.Albums.Commands
{
    public class CreateAlbumCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public AlbumModel Album { get; set; }
    }
}
