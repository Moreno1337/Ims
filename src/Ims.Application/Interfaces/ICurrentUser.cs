namespace Ims.Application.Interfaces;

public interface ICurrentUser
{
    int GetUserId();
    void SetUserId(int userId);
}