namespace ExpenseTrackerAPI.Tests.Controllers
{
    public class CategoryControllerTests
    {
        private readonly Mock<ICategoryService> _categoryServiceMock;
        private readonly CategoryController _controller;

        public CategoryControllerTests()
        {
            _categoryServiceMock = new Mock<ICategoryService>();
            _controller = new CategoryController(_categoryServiceMock.Object);
        }

        [Fact]
        public async Task ListAllCategories_ShouldReturnNotFound_WhenNoCategoriesExist()
        {
            // Arrange
            _categoryServiceMock.Setup(x => x.GetAllCategoriesAsync()).ReturnsAsync(new List<CategoryDto>());

            // Act
            var result = await _controller.ListAllCategories();

            // Assert
            var actionResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("No categories found.", actionResult.Value);
        }

        [Fact]
        public async Task ListAllCategories_ShouldReturnOk_WhenCategoriesExist()
        {
            // Arrange
            var categories = new List<CategoryDto>
            {
                new CategoryDto { Id = 1, Name = "Transportation" },
                new CategoryDto { Id = 2, Name = "Food" }
            };

            _categoryServiceMock.Setup(x => x.GetAllCategoriesAsync()).ReturnsAsync(categories);

            // Act
            var result = await _controller.ListAllCategories();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var okResult = actionResult.Value as List<CategoryDto>;
            Assert.Equal(2, okResult.Count);
            Assert.Equal("Transportation", okResult[0].Name);
            Assert.Equal("Food", okResult[1].Name);
        }
    }
}
