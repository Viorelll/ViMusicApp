﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViMusic.Application.Users.Commands.CreateUser;

namespace ViMusic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        // POST: api/createUser
        [HttpPost("createUser")]
        public async Task<IActionResult> PostCreateUser([FromBody] CreateUserCommand command)
        {
            var response = await Mediator.Send(command);

            return Json(new { Id = response });
        }
    }
}