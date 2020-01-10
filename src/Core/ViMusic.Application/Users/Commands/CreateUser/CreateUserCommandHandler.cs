using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ViMusic.Domain.Entities;
using ViMusic.Persistence;

namespace ViMusic.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly ViMusicDbContext _context;

        public CreateUserCommandHandler(ViMusicDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userModel = request.User;

            if (userModel == null) throw new Exception("User doesn't exists!");

            var user = new User
            {
                Username = userModel.Username,
                Password = userModel.Password,
                Email = userModel.Email
            };

            _context.User.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
