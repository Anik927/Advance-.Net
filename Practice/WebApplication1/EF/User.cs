using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.EF
{
    public class User
    {
		[Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required, StringLength(50), MinLength(5, ErrorMessage = "Not less than 5 char")]
		public string Password { get; set; }

		[Required, StringLength(50, ErrorMessage = "Not more than 50 char")]
		public string Name { get; set; }

		[Range(20, 50, ErrorMessage = "You'er not fit to be a user"), Required]
		public int Age { get; set; }

		[Required]
		public string BloodGroup { get; set; }

		[Required]
		public string Role { get; set; }

	}
}
