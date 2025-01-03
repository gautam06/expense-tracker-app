using ExpenseTrackerAPI.Dtos;

namespace ExpenseTrackerAPI.Repository;

public interface IExpenseRepository
{
    Task<IEnumerable<ExpenseDto>> SearchExpensesAsync(string query);
}