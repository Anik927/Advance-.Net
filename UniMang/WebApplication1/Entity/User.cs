using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entity
{
    public class User
    {        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
     
        [Required, MaxLength(100,ErrorMessage ="Username must be at most 100 characters long")]
        public string Username { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Password must be at most 100 characters long")]
        public string PasswordHash { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Role must be at most 100 characters long")]
        public string Role { get; set; } 
    }
}
