using Ims.Application.Interfaces;

namespace Ims.Infra.Services;

public class CurrentTenantService : ICurrentTenant
{
    public int GetTenantId()
    {
        return 1; // Yet to implement
    }
}
