using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabFinal2_53728.EF
{
    public class Products
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required,StringLength(100,MinimumLength =2,ErrorMessage = "Product name must be between 2 and 50 characters.")]
        public string Name { get; set; }

        [Required,StringLength(50,MinimumLength =2,ErrorMessage = "Category name must be between 2 and 100 characters.")]
        public string Category { get; set; }

        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
