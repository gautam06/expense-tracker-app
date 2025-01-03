using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseTrackerAPI.Dtos;
using ExpenseTrackerAPI.Models.Request.ExpenseTrackerAPI.Models.Request;
using ExpenseTrackerAPI.Models.Response;
using ExpenseTrackerAPI.Repository;
using ExpenseTrackerAPI.Services;
using Moq;
using Xunit;

public class ExpenseServiceTests
{
    private readonly Mock<IExpenseRepository> _mockExpenseRepository;
    private readonly ExpenseService _expenseService;

    public ExpenseServiceTests()
    {
        _mockExpenseRepository = new Mock<IExpenseRepository>();
        _expenseService = new ExpenseService(_mockExpenseRepository.Object);
    }

    [Fact]
    public async Task SearchExpensesAsync_ShouldReturnExpenses()
    {
        // Arrange
        var query = "test";
        var expectedExpenses = new List<ExpenseDto> { new ExpenseDto { Id = 1, Amount = 100 } };
        _mockExpenseRepository.Setup(repo => repo.SearchExpensesAsync(query)).ReturnsAsync(expectedExpenses);

        // Act
        var result = await _expenseService.SearchExpensesAsync(query);

        // Assert
        Assert.Equal(expectedExpenses, result);
    }

    [Fact]
    public async Task CreateExpenseAsync_ShouldReturnCreatedExpense()
    {
        // Arrange
        var expenseDto = new ExpenseDto { Id = 1, Amount = 100 };
        _mockExpenseRepository.Setup(repo => repo.CreateExpenseAsync(expenseDto)).ReturnsAsync(expenseDto);

        // Act
        var result = await _expenseService.CreateExpenseAsync(expenseDto);

        // Assert
        Assert.Equal(expenseDto, result);
    }

    [Fact]
    public async Task GetExpenseByIdAsync_ShouldReturnExpense()
    {
        // Arrange
        var id = 1;
        var expectedExpense = new ExpenseDto { Id = id, Amount = 100 };
        _mockExpenseRepository.Setup(repo => repo.GetExpenseByIdAsync(id)).ReturnsAsync(expectedExpense);

        // Act
        var result = await _expenseService.GetExpenseByIdAsync(id);

        // Assert
        Assert.Equal(expectedExpense, result);
    }

    [Fact]
    public async Task UpdateExpenseAsync_ShouldReturnUpdatedExpense()
    {
        // Arrange
        var id = 1;
        var expenseDto = new ExpenseDto { Id = id, Amount = 200 };
        _mockExpenseRepository.Setup(repo => repo.UpdateExpenseAsync(id, expenseDto)).ReturnsAsync(expenseDto);

        // Act
        var result = await _expenseService.UpdateExpenseAsync(id, expenseDto);

        // Assert
        Assert.Equal(expenseDto, result);
    }

    [Fact]
    public async Task DeleteExpenseAsync_ShouldReturnTrue()
    {
        // Arrange
        var id = 1;
        _mockExpenseRepository.Setup(repo => repo.DeleteExpenseAsync(id)).ReturnsAsync(true);

        // Act
        var result = await _expenseService.DeleteExpenseAsync(id);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task ListAllExpensesAsync_ShouldReturnExpenses()
    {
        // Arrange
        var query = new ExpenseQueryModel();
        var userId = 1;
        var expectedExpenses = new List<ExpenseDto> { new ExpenseDto { Id = 1, Amount = 100 } };
        _mockExpenseRepository.Setup(repo => repo.ListAllExpensesAsync(query, userId)).ReturnsAsync(expectedExpenses);

        // Act
        var result = await _expenseService.ListAllExpensesAsync(query, userId);

        // Assert
        Assert.Equal(expectedExpenses, result);
    }
}