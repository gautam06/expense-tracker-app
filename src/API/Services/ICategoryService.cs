using ExpenseTrackerAPI.Models;
using ExpenseTrackerAPI.Models.Response;

namespace ExpenseTrackerAPI.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
}