using ViMusic.Application.Models;

namespace ViMusic.Authentication
{
    public interface IUserProvider
    {
        UserModel Get();
    }
}