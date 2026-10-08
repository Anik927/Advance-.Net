using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FE53728API.Data.Entities
{
    public class LoginModel
    {        
        [Required,StringLength(50, ErrorMessage = "Username must be between 2 and 50 characters long.", MinimumLength = 2)]
        public string username { get; set; }
        [Required,StringLength(100, ErrorMessage = "Password must be between 6 and 100 characters long.", MinimumLength = 6)]
        public string password { get; set; }
    }
}
