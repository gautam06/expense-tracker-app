using ExpenseTrackerAPI.Context;
using ExpenseTrackerAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Services;

public class AuthService : IAuthService
{
    private readonly ExpenseTrackerContext _dbContext;

    public AuthService(ExpenseTrackerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserDetail?> AuthenticateAsync(string username, string password)
    {
        return await _dbContext.UserDetails
            .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
    }
}