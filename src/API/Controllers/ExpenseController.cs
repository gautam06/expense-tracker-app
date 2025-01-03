using ExpenseTrackerAPI.Dtos;
using ExpenseTrackerAPI.Services;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<ExpenseDto>>> SearchExpenses([FromQuery] string query)
    {
        var results = await _expenseService.SearchExpensesAsync(query);
        return Ok(results);
    }
}