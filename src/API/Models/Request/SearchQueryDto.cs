namespace ExpenseTrackerAPI.Models.Request
{
    using System.ComponentModel.DataAnnotations;

    namespace ExpenseTrackerAPI.Models.Request
    {
        public class ExpenseQueryModel
        {
            public string? Search { get; set; }
            public string? Category { get; set; }
            public string? SortBy { get; set; }
            public string? SortOrder { get; set; } = "asc";
            [Range(1, int.MaxValue, ErrorMessage = "Page number must be greater than 0.")]
            public int? PageNumber { get; set; } = 1;
            [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100.")]
            public int? PageSize { get; set; } = 10;
        }
    }
}