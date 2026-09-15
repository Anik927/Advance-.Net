using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.EF;

namespace WebApplication1.Controllers
{
    public class AccountController(CMSDbContext _context) : Controller
    {
		public IActionResult Login()
		{
			var name = User.FindFirst(ClaimTypes.Name)?.Value;
			if (name == null)
			{
				return View();
			}

			return RedirectToAction("Dashboard");

		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel viewModel)
		{

			if (!ModelState.IsValid) 
			{				
				return View(viewModel);
			}

			var user = _context.Users.FirstOrDefault(u => u.Id == viewModel.Id && u.Password == viewModel.Password);

			if (user == null)
			{
				ModelState.AddModelError("Id", "Invalid login attempt.");
				return View(viewModel);
			}

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new Claim(ClaimTypes.Name, user.Name),
				new Claim(ClaimTypes.Role, user.Role)
			};

			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

			return RedirectToAction("Dashboard");

		}

		[Authorize]
		public IActionResult Dashboard()
		{
			var id= int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
			var name = User.FindFirst(ClaimTypes.Name)?.Value;
			//var role = User.FindFirst(ClaimTypes.Role)?.Value;
			var role = ClaimTypes.Role;
			ViewBag.Name = name;
			ViewBag.Role = role;

			if (role == "Admin")
			{
				var admin = _context.Admins.FirstOrDefault(a => a.Id == id);
				ViewBag.AdminLevel = admin?.AdminLevel;
			}

			else if (role == "Student")
			{
				var student = _context.Students.FirstOrDefault(s => s.Id == id);
				ViewBag.SemesterNumber = student?.SemesterNumber;
				ViewBag.DepartmentId = student?.DepartmentId;
			}

			else if (name == null) 
			{
				return RedirectToAction("Login");
			}

				return View();

		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login");
		}

	}
}
