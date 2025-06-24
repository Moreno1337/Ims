using Ims.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Ims.Infra.Services;

public class CurrentTenantService : ICurrentTenant
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentTenantService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetTenantId()
    {
        var tenantClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("tenantId");
        var tenantId = tenantClaim?.Value ?? throw new UnauthorizedAccessException("Tenant ID not found in token.");
        return int.Parse(tenantId);
    }
}
