using Ims.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Ims.Infra.Services;

public class CurrentUserService : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetUserId()
    {
        var userClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("userId");
        var userId = userClaim?.Value ?? throw new UnauthorizedAccessException("User ID not found in token.");
        return int.Parse(userId);
    }
}
