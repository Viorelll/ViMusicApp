using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ViMusic.Application.Models;

namespace ViMusic.Authentication
{
    public static class UserProvider 
    {
        public static UserModel GetUser(this HttpContext httpContext)
        {
            var claimsIdentity = httpContext.User.Identities.First();

            var username = claimsIdentity.FindFirst("name")?.Value;
            var email = claimsIdentity.FindFirst(ClaimTypes.Email)?.Value;

            var currentUser = new UserModel
            {
                Username = username,
                Email = email
            };

            return currentUser;
        }
    }
}
