using ExpenseTrackerAPI.Context;
using ExpenseTrackerAPI.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Repository;

public class ReportRepository : IReportRepository
{
    private readonly ExpenseTrackerContext _context;

    public ReportRepository(ExpenseTrackerContext context)
    {
        _context = context;
    }

    public async Task<ReportDto> GetReportByYearAndCategoryAsync(int year, string category)
    {
        var expenses = await _context.Expenses
            .Where(e => e.CreatedAt.Year == year && e.Category.Name == category)
            .ToListAsync();

        var totalAmount = expenses.Sum(e => e.Amount);

        return new ReportDto
        {
            Year = year,
            Category = category,
            TotalAmount = totalAmount,
            Expenses = expenses
        };
    }
}