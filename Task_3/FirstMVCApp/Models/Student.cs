using FirstMVCApp.Validations;
using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class Student
    {
        [Required(ErrorMessage = "ID is required")]
        [StringLength(10, ErrorMessage = " ID can't be more than 10 char")]
        public string StudentId { set; get;  }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(100, MinimumLength =3,ErrorMessage ="Name must be between 3 and 100 char")]
        public string Name {  set; get; }

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="invalid email address")]
        public string Email {  set; get; }

        [Required(ErrorMessage ="Age is required")]
        [Range(16,40, ErrorMessage ="Age must be between 16 and 40")]
        public int Age {  set; get; }

        [Required(ErrorMessage ="GPA is required")]
        [Range(0.0,4.0,ErrorMessage ="Invalid CGPA")]
        public double GPA { set; get; }

        [Required(ErrorMessage = "Date of birth is required")]
        [MinimumAge(16)] 
        public DateTime DateOfBirth { get; set; }

    }
}
