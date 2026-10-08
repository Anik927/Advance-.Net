using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebApplication1.Entity;

namespace WebApplication1.DTOs
{
    public class StudentDTO
    {           
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }   
        public DateTime DateOfBirth { get; set; }   
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}
