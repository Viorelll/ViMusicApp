using MediatR;

namespace ViMusic.Application.Playlists.Queries.GetPlaylistsSounds
{
    public class GetPlaylistSoundQuery : IRequest<GetPlaylistSoundResponse>
    {
        public string UserId { get; set; }
    }
}
