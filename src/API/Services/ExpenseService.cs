using ExpenseTrackerAPI.Dtos;
using ExpenseTrackerAPI.Models.Request.ExpenseTrackerAPI.Models.Request;
using ExpenseTrackerAPI.Models.Response;
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
	
	public async Task<IEnumerable<ExpenseDto>> ListAllExpensesAsync(ExpenseQueryModel query, int userId)
    {
        return await _expenseRepository.ListAllExpensesAsync(query, userId);
    }
    
    public async Task<List<TotalExpensesByCategory>> GetTotalExpensesByCategoryAsync(int userId)
    {
        decimal totalAmount = 0;
        var expenses = await _expenseRepository.GetExpensesByUserIdAsync(userId);
        var totalExpensesByCategory = new Dictionary<string, decimal>();

        foreach (var expense in expenses)
        {
            if (totalExpensesByCategory.ContainsKey(expense.CategoryName))
            {
                totalExpensesByCategory[expense.CategoryName] += expense.Amount;
            }
            else
            {
                totalExpensesByCategory[expense.CategoryName] = expense.Amount;
            }
            totalAmount += expense.Amount;
        }
        
        var response = totalExpensesByCategory.Select(kvp => new TotalExpensesByCategory
        {
            CategoryName = kvp.Key,
            Amount = kvp.Value,
            Percentage = totalAmount > 0 ? (kvp.Value / totalAmount) * 100 : 0
        }).ToList();

        return response;
    }
}