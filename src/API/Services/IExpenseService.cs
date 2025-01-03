using ExpenseTrackerAPI.Dtos;

namespace ExpenseTrackerAPI.Services;

public interface IExpenseService
{
    Task<IEnumerable<ExpenseDto>> SearchExpensesAsync(string query);
}