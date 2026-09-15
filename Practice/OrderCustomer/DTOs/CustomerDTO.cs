using System.ComponentModel.DataAnnotations;

namespace OrderCustomer.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
