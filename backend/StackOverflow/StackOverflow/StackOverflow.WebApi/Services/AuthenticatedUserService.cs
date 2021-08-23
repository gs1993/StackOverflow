using Microsoft.AspNetCore.Http;
using StackOverflow.Application.Interfaces.Utils;
using System.Security.Claims;

namespace StackOverflow.WebApi.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");
        }

        public string UserId { get; }
    }
}
