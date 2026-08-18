using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Management_System.EF
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { set; get; }

        [Required,StringLength(50)]
        public string Name { set; get; }
        
        [Required,StringLength(50)]
        public string Password { set; get; }

        [Range(10,100)]
        public int Age { set; get; }

		[Required,EmailAddress]
        public string Email { set; get; }


		public DateTime DateOfBirth { set; get; }

        public int CourseId { set; get; }

        [ForeignKey("CourseId")]
        public Course Course { set; get; }

	}
}
