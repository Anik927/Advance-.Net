using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EF
{
    public class Student : User
    {        

		[Required,Range(1,12,ErrorMessage ="Invalid semester number")]
		public int SemesterNumber { get; set; }

		[Required]        
        public int DepartmentId { get; set; }

		[ForeignKey("DepartmentId")]
		public Department Department { get; set; }


    }
}
