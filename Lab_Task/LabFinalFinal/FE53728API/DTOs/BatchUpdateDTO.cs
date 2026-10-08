using System.ComponentModel.DataAnnotations;

namespace FE53728API.DTOs
{
    public class BatchUpdateDTO
    {
        [Required, StringLength(50, ErrorMessage = "Code must be between 2 and 50 characters long.", MinimumLength = 2)]
        public string Code { get; set; } = null!;

        [Required, StringLength(150, ErrorMessage = "Title must be between 2 and 150 characters long.", MinimumLength = 2)]
        public string Title { get; set; } = null!;

        [Required]
        public DateOnly StartDate { get; set; }

        [Required, Range(0, double.MaxValue, ErrorMessage = "TutionFee must be a positive number.")]
        public double TutionFee { get; set; }

        [Required, StringLength(50, ErrorMessage = "EnrollmentStatus must be between 2 and 50 characters long.", MinimumLength = 2)]
        public string EnrollmentStatus { get; set; } = null!;

        [Required]
        public int CourseId { get; set; }
    }
}
