using Microsoft.AspNetCore.Http;
using System;

namespace ViMusic.Application.Models
{
    public class SongModel
    {
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public int CreatedBy { get; set; }
        public IFormFile Cover { get; set; }
        public IFormFile Audio { get; set; }
    }
}
