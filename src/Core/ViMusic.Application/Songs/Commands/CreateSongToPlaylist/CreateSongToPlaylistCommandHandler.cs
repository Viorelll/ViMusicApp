using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ViMusic.Application.Shared.AudioWriter;
using ViMusic.Application.Shared.ImageWriter;
using ViMusic.Domain.Entities;
using ViMusic.Persistence;

namespace ViMusic.Application.Songs.Commands.CreateSongToPlaylist
{
    public class CreateSongToPlaylistCommandHandler : IRequestHandler<CreateSongToPlaylistCommand, int>
    {
        private readonly ViMusicDbContext _context;
        private readonly ImageWriter _imageWriter;
        private readonly AudioWriter _audioWriter;
        public CreateSongToPlaylistCommandHandler(ViMusicDbContext context, ImageWriter imageWriter, AudioWriter audioWriter)
        {
            _context = context;
            _imageWriter = imageWriter;
            _audioWriter = audioWriter;
        }
        public async Task<int> Handle(CreateSongToPlaylistCommand request, CancellationToken cancellationToken)
        {
            var songModel = request.Song;

            if (songModel == null) throw new Exception("Song doesn't exists!");

            var playlist = _context.Playlist.Find(request.PlaylistId);

            if (playlist == null) throw new Exception("Playlist doesn't exists!");

            //TO DO: Add more validation for song size, cover size, format, etc.
            var imageGuidUrl = await _imageWriter.UploadImage(songModel.Cover);
            var songGuidUrl = await _audioWriter.UploadAudio(songModel.Audio);

            var song = new Song
            {
                Name = songModel.Name,
                Playlist = playlist,
                Created = DateTimeOffset.Now,
                CreatedBy = request.UserId,
                CoverUrl = imageGuidUrl,
                AudioUrl = songGuidUrl
            };

            AttachAuthor(request, song);

            _context.Song.Add(song);

            await _context.SaveChangesAsync(cancellationToken);

            return song.Id;
        }

        private void AttachAuthor(CreateSongToPlaylistCommand request, Song song)
        {
            if (request.AuthorId > 0 && request.Author == null)
            {
                var author = _context.Author.Find(request.AuthorId);

                if (author != null)
                {
                    song.Author = author;
                }
            } else
            {
                song.Author = new Author
                {
                    Name = request.Author.Name
                };
            }
        }
    }
}
