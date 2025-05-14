using Ims.Application.Interfaces;

namespace Ims.Infra.Services;

public class CurrentUserService : ICurrentUser
{
    private readonly AsyncLocal<int> _currentUserId = new AsyncLocal<int>();

    public int GetUserId() => _currentUserId.Value;

    public void SetUserId(int userId) => _currentUserId.Value = userId;
}
