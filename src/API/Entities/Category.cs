

namespace ExpenseTrackerAPI.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}