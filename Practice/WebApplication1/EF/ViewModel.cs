using System.ComponentModel.DataAnnotations;

namespace WebApplication1.EF
{
    public class ViewModel
    {   
        [Required]
        public int Id { get; set; }

		[Required, StringLength(50), MinLength(5, ErrorMessage = "Not less than 5 char")]
		public string Password { get; set; }
    }
}
