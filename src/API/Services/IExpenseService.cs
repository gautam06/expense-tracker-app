using ExpenseTrackerAPI.Dtos;
using ExpenseTrackerAPI.Models.Request.ExpenseTrackerAPI.Models.Request;
using ExpenseTrackerAPI.Models.Response;

namespace ExpenseTrackerAPI.Services;

public interface IExpenseService
{
    Task<IEnumerable<ExpenseDto>> SearchExpensesAsync(string query);
    Task<ExpenseDto> CreateExpenseAsync(ExpenseDto expenseDto);
    Task<ExpenseDto> GetExpenseByIdAsync(int id);
    Task<ExpenseDto> UpdateExpenseAsync(int id, ExpenseDto expenseDto);
    Task<bool> DeleteExpenseAsync(int id);
	Task<IEnumerable<ExpenseDto>> ListAllExpensesAsync(ExpenseQueryModel query, int userId); 
	Task<List<TotalExpensesByCategory>> GetTotalExpensesByCategoryAsync(int userId);
}