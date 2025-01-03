namespace ExpenseTrackerAPI.Dtos;

public class ExpensesByCategoryDto
{
    public int UserId { get; set; }
    public string CategoryName { get; set; }
    public decimal Amount { get; set; }
}