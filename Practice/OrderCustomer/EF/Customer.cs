using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace OrderCustomer.EF
{
    public class Customer
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int CustomerId { get; set; }

        [Required, StringLength(100, MinimumLength =2,ErrorMessage ="Name must be between 2 and 100 characters.") ]
        public string Name { get; set; }
        
        [EmailAddress(ErrorMessage = "Invalid email address."), Required]
        public string Email { get; set; }

        [ValidateNever]
        public virtual List<Order> Orders { get; set; } = new List<Order>();

    }
}
