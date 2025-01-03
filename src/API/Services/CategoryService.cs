using ExpenseTrackerAPI.Context;
using ExpenseTrackerAPI.Entities;
using ExpenseTrackerAPI.Models;
using ExpenseTrackerAPI.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Services;

public class CategoryService : ICategoryService
{
    private readonly ExpenseTrackerContext _dbContext;

    public CategoryService(ExpenseTrackerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        return await _dbContext.Categories
            .OrderBy(c => c.Name)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();
    }
}