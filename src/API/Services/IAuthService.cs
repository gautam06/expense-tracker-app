using ExpenseTrackerAPI.Entities;

namespace ExpenseTrackerAPI.Services;

public interface IAuthService
{
    Task<UserDetail?> AuthenticateAsync(string username, string password);
}