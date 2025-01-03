using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Services;

namespace WebApp.Pages.Expenses;

public class ExpenseList : PageModel
{
    public class ExpensesModel : PageModel
    {
        private readonly IApiService _apiService; // Use your API service for fetching data

        public List<ExpenseDto> Expenses = new List<ExpenseDto>();
        public List<CategoryDto> Categories = new List<CategoryDto>();

        public ExpensesModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        // This method is called when the page is loaded
        public async Task OnGetAsync()
        {
            // Fetch list of expenses from API or database
            //Expenses = await _apiService.GetAsync<List<ExpenseDto>>("api/expenses");

            // Fetch categories from API for the Add Expense modal
            //Categories = await _apiService.GetAsync<List<CategoryDto>>("api/categories");
        }
    }

    // Data transfer object for Expense
    public class ExpenseDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

    // Data transfer object for Category
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}