using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.Entity
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Name must be at most 100 characters long")]
        public string Name { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Email must be at most 100 characters long"), EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey("CourseId"), ValidateNever]     
        public Course Course { get; set; }
    }
}
