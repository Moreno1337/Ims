namespace Ims.Application.Interfaces;

public interface ICurrentTenant
{
    int GetTenantId();
    void SetTenantId(int tenantId);
}