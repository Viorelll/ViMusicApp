using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ViMusic.Application.Models;
using ViMusic.Authentication;

namespace ViMusic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        protected UserModel CurrentUser => HttpContext.GetUser();
        protected string CurrentUserId => HttpContext.GetUserId();
    }
}