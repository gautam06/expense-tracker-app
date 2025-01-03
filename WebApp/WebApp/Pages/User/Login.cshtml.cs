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

        // Define the endpoint for validating the user credentials (update with actual API URL)
        var apiEndpoint = "https://third-party-api.com/validate-login";

        try
        {
            // Call the third-party API to validate the credentials
            //var response = await _apiService.PostAsync<object, object>(apiEndpoint, loginRequest);

            // If the API responds successfully, redirect the user
            return RedirectToPage("/Expenses/ExpenseList"); // Or another page as needed
        }
        catch
        {
            // Handle any errors (e.g., network issues or invalid credentials)
            ErrorMessage = "Invalid username or password, or there was an issue connecting to the authentication service.";
            return Page();
        }
    }
}