using Microsoft.AspNetCore.Http;
using System;

namespace ViMusic.Application.Models
{
    public class PlaylistModel
    {
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public int CreatedBy { get; set; }
        public IFormFile Cover { get; set; }
    }
}
