using ExpenseTrackerAPI.Entities;

namespace ExpenseTrackerAPI.Dtos;

public class ReportDto
{
    public int Year { get; set; }
    public string Category { get; set; }
    public decimal TotalAmount { get; set; }
    public List<Expense> Expenses { get; set; }
}