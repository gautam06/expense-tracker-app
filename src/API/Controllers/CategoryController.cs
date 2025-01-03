using ExpenseTrackerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("list")]
    public async Task<IActionResult> ListAllCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();

        if (!categories.Any())
        {
            return NotFound("No categories found.");
        }

        return Ok(categories);
    }
}