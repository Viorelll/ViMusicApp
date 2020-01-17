using MediatR;

namespace ViMusic.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string UserEmail { get; set; }
    }
}
