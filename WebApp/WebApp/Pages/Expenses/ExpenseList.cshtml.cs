using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages.Expenses;

public class ExpenseList : PageModel
{
    private readonly IApiService _apiService;

    public int UserId { get; set; }
    public List<ExpenseDto> Expenses { get; set; }
    public List<CategoryDto> Categories { get; set; }

    public ExpenseList(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task OnGetAsync(int userId)
    {
        UserId = userId;
        // Call the API to fetch expenses by user ID
        var apiEndpoint = $"http://localhost:5138/api/Expenses/ExpensesByCategory/{UserId}";
        Expenses = await _apiService.GetAsync<List<ExpenseDto>>(apiEndpoint);
        
        var categoryApiEndpoint = "http://localhost:5138/api/Category/list";
        Categories = await _apiService.GetAsync<List<CategoryDto>>(categoryApiEndpoint);

    }
    public IActionResult OnGet_AddExpense()
    {
        return Partial("_AddExpense", new ExpenseDto());
    }
}