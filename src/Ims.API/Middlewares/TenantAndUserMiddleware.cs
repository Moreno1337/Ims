using Ims.Application.Interfaces;

namespace Ims.API.Middlewares;

public class TenantAndUserMiddleware
{
    private readonly RequestDelegate _next;

    public TenantAndUserMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, ICurrentUser currentUser, ICurrentTenant currentTenant)
    {
        bool userHeaderIsValid = httpContext.Request.Headers.TryGetValue("X-User-Id", out var userIdHeader);
        bool tenantHeaderIsValid = httpContext.Request.Headers.TryGetValue("X-Tenant-Id", out var tenantIdHeader);

        if (!userHeaderIsValid || !tenantHeaderIsValid)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsync("Missing X-User-Id or X-Tenant-Id header.");
        }

        bool userIdIsValid = int.TryParse(userIdHeader, out int userId);
        bool tenantIdIsValid = int.TryParse(tenantIdHeader, out int tenantId);

        if (!userIdIsValid || !tenantIdIsValid)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsync("Invalid X-User-Id or X-Tenant-Id header (should be an integer).");
        }
        
        currentUser.SetUserId(userId);
        currentTenant.SetTenantId(tenantId);

        await _next(httpContext);
    }
}
