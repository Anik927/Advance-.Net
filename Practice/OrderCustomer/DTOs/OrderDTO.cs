using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OrderCustomer.EF;

namespace OrderCustomer.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }
        
        public string CustomerName { get; set; }
        
        public string CustomerEmail { get; set; }
    }
}
