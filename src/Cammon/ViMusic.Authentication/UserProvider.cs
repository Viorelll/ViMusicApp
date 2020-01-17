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

            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var username = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            var email = claimsIdentity.FindFirst(ClaimTypes.Email)?.Value;

            var currentUser = new UserModel
            {
                UserId = userId,
                Username = username,
                Email = email
            };

            return currentUser;
        }

        public static string GetUserId(this HttpContext httpContext)
        {
            var claimsIdentity = httpContext.User.Identities.First();

            return claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
