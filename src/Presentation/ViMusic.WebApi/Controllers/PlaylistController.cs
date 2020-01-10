using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViMusic.Application.Playlists.Commands;

namespace ViMusic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : BaseController
    {
        // POST: api/createPlaylist
        [HttpPost("createPlaylist")]
        public async Task<IActionResult> PostCreatePlaylist([FromForm]CreatePlaylistCommand command)
        {
            var response = await Mediator.Send(command);

            return Json(new { Id = response });
        }
    }
}