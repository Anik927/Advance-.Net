using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebApplication1.Entity;

namespace WebApplication1.DTOs
{
    public class StudentCreateDTO
    {        
        [Required, MaxLength(100, ErrorMessage = "Name must be at most 100 characters long")]
        public string Name { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Email must be at most 100 characters long"), EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int CourseId { get; set; }        
    }
}
