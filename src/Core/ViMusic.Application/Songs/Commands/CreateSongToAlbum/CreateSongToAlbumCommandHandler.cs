using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ViMusic.Application.Shared.AudioWriter;
using ViMusic.Application.Shared.ImageWriter;
using ViMusic.Domain.Entities;
using ViMusic.Persistence;

namespace ViMusic.Application.Songs.Commands.CreateSongToAlbum
{
    public class CreateSongToAlbumCommandHandler : IRequestHandler<CreateSongToAlbumCommand, int>
    {
        private readonly ViMusicDbContext _context;
        private readonly ImageWriter _imageWriter;
        private readonly AudioWriter _audioWriter;
        public CreateSongToAlbumCommandHandler(ViMusicDbContext context, ImageWriter imageWriter, AudioWriter audioWriter)
        { 
            _context = context;
            _imageWriter = imageWriter;
            _audioWriter = audioWriter;
        }
        public async Task<int> Handle(CreateSongToAlbumCommand request, CancellationToken cancellationToken)
        {
            var songModel = request.Song;

            if (songModel == null) throw new Exception("Song doesn't exists!");

            var album = _context.Album.Find(request.AlbumId);

            if (album == null) throw new Exception("Album doesn't exists!");

            //TO DO: Add more validation for song size, cover size, format, etc.
            var imageGuidUrl = await _imageWriter.UploadImage(songModel.Cover);
            var songGuidUrl = await _audioWriter.UploadAudio(songModel.Audio);

            var song = new Song
            {
                Name = songModel.Name,
                Album = album,
                Created = DateTimeOffset.Now,
                CreatedBy = request.UserId,
                AuthorId = album.AuthorId,
                CoverUrl = imageGuidUrl,
                AudioUrl = songGuidUrl
            };

            _context.Song.Add(song);

            await _context.SaveChangesAsync(cancellationToken);

            return song.Id;
        }        
    }
}
