namespace ExpenseTrackerAPI.Entities;

public partial class UserDetail
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Email { get; set; }

    public string? MobileNo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
