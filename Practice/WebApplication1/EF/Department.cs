using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.EF
{
    public class Department
    {
        [Required]
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string Name { get; set; }

		[ValidateNever]
		public List<Student> Students { get; set; }

    }
}
