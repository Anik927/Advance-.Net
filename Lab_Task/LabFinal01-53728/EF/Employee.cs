using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabFinal01_53728.EF
{
    public class Employee
    {
		[Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int EmployeeId { get; set; }

		[Required, StringLength(100)]
		public string Name { get; set; }
		
		[Required, Range(10,100)]
		public int Age { get; set; }

		[Required]
		[ForeignKey("DepartmentId")]
		public int DepartmentId { get; set; }

	}
}
