using System.ComponentModel.DataAnnotations;

namespace API2.Model
{
    public class BookCreateDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required, Range(0.01, 10000)]
        public decimal Price { get; set; }
    }
}
