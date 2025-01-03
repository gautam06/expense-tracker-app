namespace ExpenseTrackerAPI.Tests.Controllers
{
    public class ExpensesControllerTests
    {
        private readonly Mock<IExpenseService> _expenseServiceMock;
        private readonly ExpensesController _controller;

        public ExpensesControllerTests()
        {
            _expenseServiceMock = new Mock<IExpenseService>();
            _controller = new ExpensesController(_expenseServiceMock.Object);
        }

        [Fact]
        public async Task UpdateExpense_ShouldReturnNoContent_WhenExpenseIsUpdated()
        {
            // Arrange
            var expenseDto = new ExpenseDto { Id = 1, Description = "Lunch", Amount = (decimal)50.0 };
            _expenseServiceMock.Setup(x => x.UpdateExpenseAsync(1, expenseDto)).ReturnsAsync(expenseDto);

            // Act
            var result = await _controller.UpdateExpense(1, expenseDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateExpense_ShouldReturnNotFound_WhenExpenseDoesNotExist()
        {
            // Arrange
            var expenseDto = new ExpenseDto { Id = 1, Description = "Lunch", Amount = (decimal)50.0 };
            _expenseServiceMock.Setup(x => x.UpdateExpenseAsync(1, expenseDto)).ReturnsAsync((ExpenseDto)null);

            // Act
            var result = await _controller.UpdateExpense(1, expenseDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteExpense_ShouldReturnNoContent_WhenExpenseIsDeleted()
        {
            // Arrange
            _expenseServiceMock.Setup(x => x.DeleteExpenseAsync(1)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteExpense(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteExpense_ShouldReturnNotFound_WhenExpenseDoesNotExist()
        {
            // Arrange
            _expenseServiceMock.Setup(x => x.DeleteExpenseAsync(1)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteExpense(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
