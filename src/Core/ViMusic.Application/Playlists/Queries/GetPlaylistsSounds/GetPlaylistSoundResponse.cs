using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ViMusic.Application.Shared.AudioWriter;
using ViMusic.Application.Shared.ImageWriter;
using ViMusic.Domain.Entities;

namespace ViMusic.Application.Playlists.Queries.GetPlaylistsSounds
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
                                        Songs = x.Songs.Select(s => new GetSongModel
                                        {
                                            Name = s.Name,
                                            Created = s.Created,
                                            CreatedBy = s.CreatedBy,
                                            CoverUrl = ImageWriter.GetImageRootPath(s.CoverUrl),
                                            AudioUrl = AudioWriter.GetImageRootPath(s.AudioUrl),
                                            AuthorName = s.Author.Name
                                        }).ToList()
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
