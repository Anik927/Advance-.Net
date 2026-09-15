using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebApplication1.Entity;

namespace WebApplication1.DTOs
{
    public class CourseDTO
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }

        [ValidateNever]
        public List<Student> Students { get; set; }
    }
}
