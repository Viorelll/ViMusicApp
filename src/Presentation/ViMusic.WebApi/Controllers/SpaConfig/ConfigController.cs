using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ViMusic.WebApi.Models;

namespace ViMusic.WebApi.Controllers.SpaConfig
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IOptions<ConfigModel> config;

        public ConfigController(IOptions<ConfigModel> config)
        {
            this.config = config;
        }

        [AllowAnonymous]
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(config.Value);
        }
    }
}