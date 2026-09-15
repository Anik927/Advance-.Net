using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entity;

namespace WebApplication1.Controllers
{
    public class AccountController(UniMContext context) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }
            var user = context.Users.FirstOrDefault(u => u.Username == loginModel.Username && u.PasswordHash == loginModel.PasswordHash);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var identity = new ClaimsIdentity(claims, "login");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("login", principal);
                return RedirectToAction("Dashboard", "Account");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View(loginModel);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("login");
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Dashboard()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
