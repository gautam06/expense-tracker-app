namespace ExpenseTrackerAPI.Entities;

public partial class Expense
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public int UserId { get; set; }

    public int CategoryId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastModifiedAt { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual UserDetail User { get; set; } = null!;
}
