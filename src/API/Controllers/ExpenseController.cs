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
	
	[HttpGet("list")]
    public async Task<ActionResult<IEnumerable<ExpenseDto>>> ListAllExpenses([FromQuery] ExpenseQueryModel query, int userId)
    {
        var results = await _expenseService.ListAllExpensesAsync(query, userId);
        return Ok(results);
    }
    
    [HttpGet("ExpensesByCategory/{userId}")]
    public async Task<ActionResult<Dictionary<string, decimal>>> GetTotalExpensesByCategory(int userId)
    {
        
        //Added Invalid User Error
        if (userId <= 0)
        {
            return BadRequest("Invalid userId.");
        }
        
        var result = await _expenseService.GetTotalExpensesByCategoryAsync(userId);
        return Ok(result);
    }
}