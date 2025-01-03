using ExpenseTrackerAPI.Dtos;
using ExpenseTrackerAPI.Repository;

namespace ExpenseTrackerAPI.Services;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _expenseRepository;

    public ExpenseService(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    public async Task<IEnumerable<ExpenseDto>> SearchExpensesAsync(string query)
    {
        return await _expenseRepository.SearchExpensesAsync(query);
    }
}

