using ExpenseTrackerAPI.Dtos;
using ExpenseTrackerAPI.Repository;

namespace ExpenseTrackerAPI.Services;

public class ReportService :IReportService
{
    
    private readonly IReportRepository _reportRepository;

    public ReportService(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public async Task<ReportDto> GetReportByYearAndCategoryAsync(int year, string category)
    {
        return await _reportRepository.GetReportByYearAndCategoryAsync(year, category);
    }
}