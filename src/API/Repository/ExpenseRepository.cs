using ExpenseTrackerAPI.Dtos;

namespace ExpenseTrackerAPI.Repository;

public abstract class ExpenseRepository : IExpenseRepository
{
    public abstract Task<IEnumerable<ExpenseDto>> SearchExpensesAsync(string query);
}