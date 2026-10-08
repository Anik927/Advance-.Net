using System.ComponentModel.DataAnnotations;
using FE53728API.Data.Entities;

namespace FE53728API.DTOs
{
    public class BatchDTO
    {

        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string Title { get; set; } = null!;

        public DateOnly StartDate { get; set; }

        public double TutionFee { get; set; }

        public string EnrollmentStatus { get; set; } = null!;

        public int CourseId { get; set; }

        public Course course { get; set; }

    }
}
