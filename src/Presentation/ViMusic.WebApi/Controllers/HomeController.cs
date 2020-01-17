using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ViMusic.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : BaseController
    {

        private readonly ILogger<HomeController> _logger;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [Authorize]
        [HttpGet]
        public IActionResult Get()
        
        {
            //return Summaries;
            var user = HttpContext.User;

            return Json(new { Result = user });
        }

   
    }
}
