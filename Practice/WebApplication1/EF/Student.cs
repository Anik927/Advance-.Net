using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.EF
{
    public class Student
    {        

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		[Required,Range(1,12,ErrorMessage ="Invalid semester number")]
		public int SemesterNumber { get; set; }

		[Required]        
        public int DepartmentId { get; set; }

		[ForeignKey("DepartmentId")]
		[ValidateNever]
		public Department Department { get; set; }
		
		
		[ForeignKey("Id")]
		public virtual User User { get; set; }


	}
}
