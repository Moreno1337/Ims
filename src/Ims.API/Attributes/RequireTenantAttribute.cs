using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ims.API.Attributes;

public class RequireTenantAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var user = context.HttpContext.User;
        var tenantId = user.FindFirst("tenantId")?.Value;

        if (string.IsNullOrEmpty(tenantId))
        {
            context.Result = new BadRequestObjectResult("Tenant ID is required.");
            return;
        }
    }
}