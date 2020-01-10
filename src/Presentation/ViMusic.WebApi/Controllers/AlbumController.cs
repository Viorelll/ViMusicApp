using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViMusic.Application.Albums.Commands;

namespace ViMusic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : BaseController
    {
        // POST: api/createAlbum
        [HttpPost("createAlbum")]
        public async Task<IActionResult> PostCreateAlbum([FromForm]CreateAlbumCommand command)
        {
            var response = await Mediator.Send(command);

            return Json(new { Id = response });
        }
    }
}