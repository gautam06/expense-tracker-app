using ExpenseTrackerAPI.Dtos;
using ExpenseTrackerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using ExpenseTrackerAPI.Models.Request.ExpenseTrackerAPI.Models.Request;

namespace ExpenseTrackerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IExpenseService _expenseService;

    public ExpensesController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    [HttpGet("list")]
    public async Task<ActionResult<IEnumerable<ExpenseDto>>> ListAllExpenses([FromQuery] ExpenseQueryModel query, int userId)
    {
        var results = await _expenseService.ListAllExpensesAsync(query, userId);
        return Ok(results);
    }
}