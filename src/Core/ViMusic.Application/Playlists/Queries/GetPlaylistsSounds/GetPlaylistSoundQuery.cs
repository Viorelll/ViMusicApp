using MediatR;

namespace ViMusic.Application.Playlists.Queries.GetPlaylistsSounds
{
    public class GetPlaylistSoundQuery : IRequest<GetPlaylistSoundResponse>
    {
        public int UserId { get; set; }
    }
}
