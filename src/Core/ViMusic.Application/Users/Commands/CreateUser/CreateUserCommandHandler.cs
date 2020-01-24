using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ViMusic.Domain.Entities;
using ViMusic.Persistence;

namespace ViMusic.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly ViMusicDbContext _context;

        public CreateUserCommandHandler(ViMusicDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new Exception("User doesn't exists!");

            var user = await _context.User.AsNoTracking().FirstOrDefaultAsync(x => x.Email == request.UserEmail);
            if (user == null)
            {
                var newUser = new User
                {
                    Username = request.Username,
                    Email = request.UserEmail
                };

                _context.User.Add(newUser);

                await _context.SaveChangesAsync(cancellationToken);
            }

            return default;
        }
    }
}
