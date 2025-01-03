namespace ExpenseTrackerAPI.Models.Request;

public class SigninRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}