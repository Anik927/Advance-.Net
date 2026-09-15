using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OrderCustomer.EF;

namespace OrderCustomer.DTOs
{
    public class OrderCreateDTO
    {        

        [Required, StringLength(70, MinimumLength = 2, ErrorMessage = "Product name must be between 2 and 70 characters.")]
        public string ProductName { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive integer.")]
        public int Quantity { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public int CustomerId { get; set; }
        
    }
}
