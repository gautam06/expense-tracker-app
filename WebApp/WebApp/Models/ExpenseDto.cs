namespace WebApp.Models;

public class ExpenseDto
{
    //public int Id { get; set; }
    public decimal Amount { get; set; }
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
}