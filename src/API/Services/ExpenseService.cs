using ExpenseTrackerAPI.Dtos;
using ExpenseTrackerAPI.Models.Request.ExpenseTrackerAPI.Models.Request;
using ExpenseTrackerAPI.Repository;

namespace ExpenseTrackerAPI.Services;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _expenseRepository;

    public ExpenseService(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    
    public async Task<IEnumerable<ExpenseDto>> ListAllExpensesAsync(ExpenseQueryModel query, int userId)
    {
        return await _expenseRepository.ListAllExpensesAsync(query, userId);
    }
    
    // public async Task<IEnumerable<ExpenseDto>> SearchExpensesAsync(SearchQueryModel query)
    // {
    //     SearchQuery searchQuery = new SearchQuery
    //     {
    //         Query = query.Query
    //     };
    //     return await _expenseRepository.SearchExpensesAsync(searchQuery);
    // }

}

