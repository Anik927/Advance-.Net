using System.ComponentModel.DataAnnotations;

namespace Course_Management_System.EF
{
    public class LoginViewModel
    {
		[Required]		
		public int StudentId { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
