namespace ExpenseTrackerAPI.Dtos;

public class ExpenseDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public DateTime Date { get; set; }
    
    public string Category { get; set; }
}