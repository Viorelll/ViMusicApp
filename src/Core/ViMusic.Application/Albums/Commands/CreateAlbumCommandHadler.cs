using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ViMusic.Application.Models;
using ViMusic.Application.Shared.ImageWriter;
using ViMusic.Domain.Entities;
using ViMusic.Persistence;

namespace ViMusic.Application.Albums.Commands
{
    public class CreateAlbumCommandHadler : IRequestHandler<CreateAlbumCommand, int>
    {
        private readonly ViMusicDbContext _context;
        private readonly ImageWriter _imageWriter;
        public CreateAlbumCommandHadler(ViMusicDbContext context, ImageWriter imageWriter)
        {
            _context = context;
            _imageWriter = imageWriter;
        }
        public async Task<int> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var albumModel = request.Album;

            if (albumModel == null) throw new Exception("Album doesn't exists!");

            var imageGuidUrl = await _imageWriter.UploadImage(albumModel.Cover);

            var album = new Album
            {
                Name = albumModel.Name,
                Created = DateTimeOffset.Now,
                CreatedBy = request.UserId,
                CoverUrl = imageGuidUrl
            };

            AttachAuthor(albumModel, album);

            album.UserId = request.UserId;

            _context.Album.Add(album);

            await _context.SaveChangesAsync(cancellationToken);

            return album.Id;
        }

        private void AttachAuthor(AlbumModel request, Album album)
        {
            if (request.AuthorId > 0 && request.Author == null)
            {
                var author = _context.Author.Find(request.AuthorId);

                if (author != null)
                {
                    album.Author = author;
                }
            }
            else
            {
                album.Author = new Author
                {
                    Name = request.Author.Name
                };
            }
        }
    }
}
