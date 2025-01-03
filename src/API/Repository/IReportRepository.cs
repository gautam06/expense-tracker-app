using ExpenseTrackerAPI.Dtos;

namespace ExpenseTrackerAPI.Repository;

public interface IReportRepository
{
    Task<ReportDto> GetReportByYearAndCategoryAsync(int year, string category);
}