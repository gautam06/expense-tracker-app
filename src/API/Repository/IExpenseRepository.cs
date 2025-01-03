using ExpenseTrackerAPI.Dtos;

namespace ExpenseTrackerAPI.Repository;

public interface IExpenseRepository
{
    Task<IEnumerable<ExpenseDto>> SearchExpensesAsync(string query);
    Task<ExpenseDto> CreateExpenseAsync(ExpenseDto expenseDto);
    Task<ExpenseDto> GetExpenseByIdAsync(int id);
    Task<ExpenseDto> UpdateExpenseAsync(int id, ExpenseDto expenseDto);
    Task<bool> DeleteExpenseAsync(int id);
}