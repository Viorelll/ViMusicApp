using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViMusic.Application.Songs.Commands.CreateSongToAlbum;
using ViMusic.Application.Songs.Commands.CreateSongToPlaylist;

namespace ViMusic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : BaseController
    {
        // POST: api/AttachSongToPlaylist
        [HttpPost("AttachSongToPlaylist")]
        public async Task<IActionResult> PostAttachSongToPlaylist([FromForm] CreateSongToPlaylistCommand command)
        {
            var response = await Mediator.Send(command);

            return Json(new { Id = response });
        }

        // POST: api/AttachSongToAlbum
        [HttpPost("AttachSongToAlbum")]
        public async Task<IActionResult> PostAttachSongToAlbum([FromForm] CreateSongToAlbumCommand command)
        {
            var response = await Mediator.Send(command);

            return Json(new { Id = response });
        }
    }
}