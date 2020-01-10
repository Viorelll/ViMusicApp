using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ViMusic.Application.Shared.ImageWriter;
using ViMusic.Domain.Entities;
using ViMusic.Persistence;

namespace ViMusic.Application.Playlists.Commands
{
    public class CreateAlbumCommandHadler : IRequestHandler<CreatePlaylistCommand, int>
    {
        private readonly ViMusicDbContext _context;
        private readonly ImageWriter _imageWriter;
        public CreateAlbumCommandHadler(ViMusicDbContext context, ImageWriter imageWriter)
        {
            _context = context;
            _imageWriter = imageWriter;
        }
        public async Task<int> Handle(CreatePlaylistCommand request, CancellationToken cancellationToken)
        {
            var playlistModel = request.Playlist;

            if (playlistModel == null) throw new Exception("Playlist doesn't exists!");

            var imageGuidUrl = await _imageWriter.UploadImage(playlistModel.Cover);

            var playlist = new Playlist
            {
                Name = playlistModel.Name,
                Created = DateTimeOffset.Now,
                CreatedBy = request.UserId,
                CoverUrl = imageGuidUrl
            };

            playlist.UserId = request.UserId;

            _context.Playlist.Add(playlist);

            await _context.SaveChangesAsync(cancellationToken);

            return playlist.Id;
        }
    }
}
