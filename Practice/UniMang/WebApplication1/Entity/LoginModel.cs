using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entity
{
    public class LoginModel
    {                
        
        [Required, MaxLength(100, ErrorMessage = "Username must be at most 100 characters long")]
        public string Username { get; set; }
        
        [Required, MaxLength(100, ErrorMessage = "Password must be at most 100 characters long")]
        public string PasswordHash { get; set; }

    }
}
