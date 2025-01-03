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

    public async Task<IEnumerable<ExpenseDto>> SearchExpensesAsync(string query)
    {
        return await _context.Expenses
            .Where(e => e.Description.Contains(query))
            .Select(e => new ExpenseDto
            {
                Id = e.Id,
                Amount = e.Amount,
                Description = e.Description,
                UserId = e.UserId,
                CategoryId = e.CategoryId
            })
            .ToListAsync();
    }

    public async Task<ExpenseDto> CreateExpenseAsync(ExpenseDto expenseDto)
    {
        var expense = new Expense
        {
            Amount = expenseDto.Amount,
            Description = expenseDto.Description,
            UserId = expenseDto.UserId,
            CategoryId = expenseDto.CategoryId,
            CreatedAt = DateTime.UtcNow,
            LastModifiedAt = DateTime.UtcNow
        };

        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();

        expenseDto.Id = expense.Id;
        return expenseDto;
    }

    public async Task<ExpenseDto> GetExpenseByIdAsync(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null)
        {
            return null;
        }

        return new ExpenseDto
        {
            Id = expense.Id,
            Amount = expense.Amount,
            Description = expense.Description,
            UserId = expense.UserId,
            CategoryId = expense.CategoryId
        };
    }

    public async Task<ExpenseDto> UpdateExpenseAsync(int id, ExpenseDto expenseDto)
    {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null)
        {
            return null;
        }

        expense.Amount = expenseDto.Amount;
        expense.Description = expenseDto.Description;
        expense.UserId = expenseDto.UserId;
        expense.CategoryId = expenseDto.CategoryId;
        expense.LastModifiedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return expenseDto;
    }

    public async Task<bool> DeleteExpenseAsync(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null)
        {
            return false;
        }

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();

        return true;
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
        var skip = ((query.PageNumber ?? 1) - 1) * (query.PageSize ?? 10);
        expenses = expenses.Skip(skip).Take(query.PageSize ?? 10);

        return await expenses.Select(e => new ExpenseDto
        {
            Id = e.Id,
            Amount = e.Amount,
            Date = e.ExpenseDate,
            Category = e.Category.Name,
            Description = e.Description
        }).ToListAsync();
    }
    
    public async Task<IEnumerable<ExpensesByCategoryDto>> GetExpensesByUserIdAsync(int userId)
    {
        return await _context.Expenses
            .Where(e => e.UserId == userId)
            .Join(_context.Categories,
                expense => expense.CategoryId,
                category => category.Id,
                (expense, category) => new ExpensesByCategoryDto
                {
                    UserId = expense.UserId,
                    CategoryName = category.Name,
                    Amount = expense.Amount
                })
            .ToListAsync();
    }
}