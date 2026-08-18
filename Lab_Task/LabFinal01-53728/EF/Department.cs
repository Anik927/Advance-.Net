using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabFinal01_53728.EF
{
    public class Department
    {
		[Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DepartmentId { get; set; }

		[Required,StringLength(100)]
		public string Title { get; set; }

		public List<Employee> Employees { get; set; }


	}
}
