using Ims.Application.Interfaces;

namespace Ims.Infra.Services;

public class CurrentTenantService : ICurrentTenant
{
    private readonly AsyncLocal<int> _currentTenantId = new AsyncLocal<int>();

    public int GetTenantId() => _currentTenantId.Value;

    public void SetTenantId(int tenantId) => _currentTenantId.Value = tenantId;
}
