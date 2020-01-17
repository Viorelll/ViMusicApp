using MediatR;

namespace ViMusic.Application.Playlists.Queries.GetPlaylists
{
    public class GetPlaylistQuery : IRequest<GetPlaylistSoundResponse>
    {
        public string UserId { get; set; }
    }
}
