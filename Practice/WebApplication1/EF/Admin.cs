using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EF
{
	public class Admin
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		[ForeignKey("Id")]
		public virtual User User { get; set; }

		[Required, Range(1, 3, ErrorMessage = "Invalid admin Level")]
		public int AdminLevel { get; set; }					

	}
}
