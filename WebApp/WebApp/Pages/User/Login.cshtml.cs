using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Services;

namespace WebApp.Pages.User;

public class LoginModel : PageModel
{
    private readonly IApiService _apiService;

    public LoginModel(IApiService apiService)
    {
        _apiService = apiService;
    }

    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public string ErrorMessage { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        // Prepare the request object for the third-party API
        var loginRequest = new
        {
            Username = Username,
            Password = Password
        };

        // Define the endpoint for validating the user credentials
        var apiEndpoint = "http://localhost:5138/api/Auth/signin";

        try
        {
            // Call the third-party API to validate the credentials
            var response = await _apiService.PostAsync<object, LoginResponse>(apiEndpoint, loginRequest);

            if (response.UserId > 0)
            {
                // If successful, redirect the user
                return RedirectToPage("/Expenses/ExpenseList");
            }
            else
            {
                // Handle other cases (e.g., invalid credentials)
                ErrorMessage = "Invalid username or password.";
            }
        }
        catch (Exception ex)
        {
            // Handle unexpected errors
            ErrorMessage = $"An error occurred: {ex.Message}";
        }

        return Page();
    }

    public class LoginResponse
    {
        public int UserId { get; set; }
    }
}