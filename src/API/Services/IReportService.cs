using ExpenseTrackerAPI.Dtos;

namespace ExpenseTrackerAPI.Services;

public interface IReportService
{
    Task<ReportDto> GetReportByYearAndCategoryAsync(int year, string category);

}