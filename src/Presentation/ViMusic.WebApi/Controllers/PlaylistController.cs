using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViMusic.Application.Playlists.Commands;
using ViMusic.Application.Playlists.Queries.GetPlaylists;
using ViMusic.Application.Playlists.Queries.GetPlaylistsSounds;

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

        // GET: api/getPlaylists
        [HttpGet("getPlaylists")]
        public async Task<IActionResult> GetPlaylists()
        {
            var query = new GetPlaylistQuery { UserId = CurrentUserId };
            var response = await Mediator.Send(query);

            return Json(response);
        }

        // GET: api/getPlaylists
        [HttpGet("getPlaylistsSound")]
        public async Task<IActionResult> GetPlaylistsSound([FromBody]GetPlaylistSoundQuery query)
        {
            var response = await Mediator.Send(query);

            return Json(response);
        }
    }
}