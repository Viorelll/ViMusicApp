﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ViMusic.Persistence;

namespace ViMusic.Application.Playlists.Queries.GetPlaylistsSounds
{
    public class GetPlaylistSoundQueryHander : IRequestHandler<GetPlaylistSoundQuery, GetPlaylistSoundResponse>
    {
        private readonly ViMusicDbContext _context;

        public GetPlaylistSoundQueryHander(ViMusicDbContext context)
        {
            _context = context;
        }

        public async Task<GetPlaylistSoundResponse> Handle(GetPlaylistSoundQuery request, CancellationToken cancellationToken)
        {
            var playlists = await _context.Playlist.Where(x => x.UserId == request.UserId).ToListAsync();

            if (playlists == null)
            {
                throw new Exception("Playlists doesn't exists!");
            }

            return GetPlaylistSoundResponse.Create(playlists);
        }
    }
}
