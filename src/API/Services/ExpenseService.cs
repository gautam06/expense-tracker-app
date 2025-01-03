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

    public async Task<ExpenseDto> CreateExpenseAsync(ExpenseDto expenseDto)
    {
        return await _expenseRepository.CreateExpenseAsync(expenseDto);
    }

    public async Task<ExpenseDto> GetExpenseByIdAsync(int id)
    {
        return await _expenseRepository.GetExpenseByIdAsync(id);
    }

    public async Task<ExpenseDto> UpdateExpenseAsync(int id, ExpenseDto expenseDto)
    {
        return await _expenseRepository.UpdateExpenseAsync(id, expenseDto);
    }

    public async Task<bool> DeleteExpenseAsync(int id)
    {
        return await _expenseRepository.DeleteExpenseAsync(id);
    }
}