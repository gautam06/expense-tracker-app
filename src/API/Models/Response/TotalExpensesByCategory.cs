namespace ExpenseTrackerAPI.Models.Response;

public class TotalExpensesByCategory
{
    public string CategoryName { get; set; }
    public decimal Amount { get; set; }
    
    public decimal Percentage { get; set; }
    
}