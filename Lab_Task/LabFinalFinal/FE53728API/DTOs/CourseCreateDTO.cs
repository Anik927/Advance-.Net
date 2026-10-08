using System.ComponentModel.DataAnnotations;

namespace FE53728API.DTOs
{
    public class CourseCreateDTO
    {
        [Required, StringLength(50, ErrorMessage = "Code must be between 2 and 50 characters long.", MinimumLength = 2)]
        public string Code { get; set; } = null!;

        [Required, StringLength(150, ErrorMessage = "Title must be between 2 and 150 characters long.", MinimumLength = 2)]
        public string Title { get; set; } = null!;

        [Required, Range(0, int.MaxValue, ErrorMessage = "TotalHrs must be a positive number.")]
        public int TotalHrs { get; set; }
    }
}
