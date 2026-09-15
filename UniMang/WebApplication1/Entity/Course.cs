using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.Entity
{
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(200, ErrorMessage = "Title must be at most 200 characters long")]
        public string Title { get; set; }

        [Required, StartDate]
        public DateTime StartDate { get; set; }

        [ValidateNever]
        public List<Student> Students { get; set; }

    }
}
