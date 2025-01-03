using Microsoft.AspNetCore.Mvc;
using ExpenseTrackerAPI.Services;

namespace ExpenseTrackerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    
    /// <summary>
    /// This API will provide data based on Year and Category
    /// </summary>
    /// <param name="year"></param>
    /// <param name="category"></param>
    /// <returns></returns>
    [HttpGet("{year}/{category}")]
    public async Task<IActionResult> GetReport(int year, string category)
    {
        var report = await _reportService.GetReportByYearAndCategoryAsync(year, category);
        if (report == null)
        {
            return NotFound();
        }
        return Ok(report);
    }
    
    
}