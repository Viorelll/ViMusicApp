using MediatR;
using ViMusic.Application.Models;

namespace ViMusic.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public UserModel User { get; set; }
    }
}
