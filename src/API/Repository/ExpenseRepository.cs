
using ExpenseTrackerAPI.Context;
using ExpenseTrackerAPI.Dtos;
using ExpenseTrackerAPI.Entities;
using ExpenseTrackerAPI.Models.Request.ExpenseTrackerAPI.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Repository;

public class ExpenseRepository : IExpenseRepository
{
    private readonly ExpenseTrackerContext _context;

    public ExpenseRepository(ExpenseTrackerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ExpenseDto>> ListAllExpensesAsync(ExpenseQueryModel query, int userId)
    {
        IQueryable<Expense> expenses = _context.Expenses.Include(e => e.Category).AsQueryable();

        // Filter by user
        expenses = expenses.Where(e => e.UserId == userId);
        
        // Search
        if (!string.IsNullOrEmpty(query.Search))
        {
            expenses = expenses.Where(e => EF.Functions.Like(e.Description, $"%{query.Search}%") ||
                                           EF.Functions.Like(e.Category.Name, $"%{query.Search}%"));
        }

        // Filter by category
        if (!string.IsNullOrEmpty(query.Category))
        {
            expenses = expenses.Where(e => e.Category.Name == query.Category);
        }

        // Sorting
        if (!string.IsNullOrEmpty(query.SortBy))
        {
            expenses = query.SortBy.ToLower() switch
            {
                "amount" => query.SortOrder == "desc" ? expenses.OrderByDescending(e => e.Amount) : expenses.OrderBy(e => e.Amount),
                "date" => query.SortOrder == "desc" ? expenses.OrderByDescending(e => e.ExpenseDate) : expenses.OrderBy(e => e.ExpenseDate),
                _ => expenses
            };
        }

        // Pagination
        var skip = (query.PageNumber - 1) * query.PageSize;
        expenses = expenses.Skip(skip).Take(query.PageSize);

        return await expenses.Select(e => new ExpenseDto
        {
            Id = e.Id,
            Amount = e.Amount,
            Date = e.ExpenseDate,
            Category = e.Category.Name,
            Description = e.Description
        }).ToListAsync();
    }
}