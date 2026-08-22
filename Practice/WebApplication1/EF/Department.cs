using System.ComponentModel.DataAnnotations;

namespace WebApplication1.EF
{
    public class Department
    {
        [Required]
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string Name { get; set; }

        public List<Student> Students { get; set; }

    }
}
