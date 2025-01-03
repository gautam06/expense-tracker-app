using ExpenseTrackerAPI.Dtos;
using ExpenseTrackerAPI.Models.Request.ExpenseTrackerAPI.Models.Request;

namespace ExpenseTrackerAPI.Repository;

public interface IExpenseRepository
{
   Task<IEnumerable<ExpenseDto>> ListAllExpensesAsync(ExpenseQueryModel query, int userId);
}