using System.Security.Claims;
using FE53728API.Data;
using FE53728API.Data.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FE53728API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(CourseManegmentContext context) : ControllerBase
    {
        public async Task<IActionResult> Login(LoginModel loginModel)
        {

            if(loginModel.username.IsNullOrEmpty() || loginModel.password.IsNullOrEmpty())
            {
                return BadRequest("Username and password are required");
            }

            var user = context.Users.FirstOrDefault(u => u.Username == loginModel.username && u.Password == loginModel.password);

            if(user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            var claims = new List<Claim>
            {
                
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync("login", claimsPrincipal);

            return Ok(new { message = "Login successful" });

        }
    }
}
