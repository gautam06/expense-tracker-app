using ExpenseTrackerAPI.Dtos;

namespace ExpenseTrackerAPI.Services;

public interface IExpenseService
{
    Task<IEnumerable<ExpenseDto>> SearchExpensesAsync(string query);
    Task<ExpenseDto> CreateExpenseAsync(ExpenseDto expenseDto);
    Task<ExpenseDto> GetExpenseByIdAsync(int id);
    Task<ExpenseDto> UpdateExpenseAsync(int id, ExpenseDto expenseDto);
    Task<bool> DeleteExpenseAsync(int id);
}