using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ViMusic.Application.Shared.ImageWriter;
using ViMusic.Domain.Entities;

namespace ViMusic.Application.Playlists.Queries.GetPlaylists
{
    public class GetPlaylistSoundResponse
    {
        public ICollection<GetPlaylistSoundModel> Playlists { get; set; } = new List<GetPlaylistSoundModel>();

        public static Expression<Func<List<Playlist>, GetPlaylistSoundResponse>> Projection
        {
            get
            {
                return playlists => new GetPlaylistSoundResponse
                {
                    Playlists = playlists
                                    .Select(x => new GetPlaylistSoundModel
                                    { 
                                        Name = x.Name,
                                        Created = x.Created,
                                        CreatedBy = x.CreatedBy,
                                        CoverUrl = ImageWriter.GetImageRootPath(x.CoverUrl),
                                    })
                                    .ToList()
                };
            }
        }

        public static GetPlaylistSoundResponse Create(List<Playlist> playlists)
        {
            return Projection.Compile().Invoke(playlists);
        }
    }
}
