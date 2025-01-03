using ExpenseTrackerAPI.Context;
using ExpenseTrackerAPI.Dtos;
using ExpenseTrackerAPI.Entities;
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
}