using ExpenseTrackerAPI.Repository;

public class ReportServiceTests
{
    private readonly Mock<IReportRepository> _mockReportRepository;
    private readonly ReportService _reportService;

    public ReportServiceTests()
    {
        _mockReportRepository = new Mock<IReportRepository>();
        _reportService = new ReportService(_mockReportRepository.Object);
    }

    [Fact]
    public async Task GetReportByYearAndCategoryAsync_ShouldReturnReport()
    {
        // Arrange
        var year = 2023;
        var category = "Food";
        var expectedReport = new ReportDto { Year = year, Category = category, TotalAmount = 1000 };
        _mockReportRepository.Setup(repo => repo.GetReportByYearAndCategoryAsync(year, category)).ReturnsAsync(expectedReport);

        // Act
        var result = await _reportService.GetReportByYearAndCategoryAsync(year, category);

        // Assert
        Assert.Equal(expectedReport, result);
    }
}