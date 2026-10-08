using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace APIFinalTest.EF
{
    public class Patient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, Range(0, 120, ErrorMessage = "Age must be between 0 and 120.")]
        public int Age { get; set; }

        [Required, MaxLength(200)]
        public string Address { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [ForeignKey("DoctorId"), ValidateNever]
        public Doctor Doctor { get; set; }
    }
}
