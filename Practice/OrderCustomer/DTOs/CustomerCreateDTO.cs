using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderCustomer.DTOs
{
    public class CustomerCreateDTO
    {
        [Required, StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address."), Required]
        public string Email { get; set; }
    }
}
