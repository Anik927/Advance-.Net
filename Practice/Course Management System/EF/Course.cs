using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Management_System.EF
{
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        
        [Required,StringLength(100)]
        public string Title { get; set; }
        
        public int Duration { get; set; }

        public virtual List<Student> Students { get; set; } = new List<Student>();

	}
}
