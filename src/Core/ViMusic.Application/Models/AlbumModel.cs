using Microsoft.AspNetCore.Http;
using System;

namespace ViMusic.Application.Models
{
    public class AlbumModel
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public AuthorModel Author { get; set; }
        public DateTimeOffset Created { get; set; }
        public int CreatedBy { get; set; }
        public IFormFile Cover { get; set; }
    }
}
