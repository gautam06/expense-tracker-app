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

    [HttpPost]
    public async Task<ActionResult<ExpenseDto>> CreateExpense([FromBody] ExpenseDto expenseDto)
    {
        var createdExpense = await _expenseService.CreateExpenseAsync(expenseDto);
        return CreatedAtAction(nameof(GetExpenseById), new { id = createdExpense.Id }, createdExpense);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseDto>> GetExpenseById(int id)
    {
        var expense = await _expenseService.GetExpenseByIdAsync(id);
        if (expense == null)
        {
            return NotFound();
        }
        return Ok(expense);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExpense(int id, [FromBody] ExpenseDto expenseDto)
    {
        var updatedExpense = await _expenseService.UpdateExpenseAsync(id, expenseDto);
        if (updatedExpense == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense(int id)
    {
        var deleted = await _expenseService.DeleteExpenseAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}