namespace Ims.API.Auth;

public class TenantSwitchRequest
{
    public int UserId { get; set; }
    public int TenantId { get; set; }
}