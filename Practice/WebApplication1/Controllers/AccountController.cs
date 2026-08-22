using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.EF;

namespace WebApplication1.Controllers
{
    public class AccountController(CMSDbContext _context) : Controller
    {
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(ViewModel viewModel)
		{

			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}

			var student = _context.Users.FirstOrDefault(s => s.Id == viewModel.Id && s.Password == viewModel.Password);
			if (student == null)
			{
				ModelState.AddModelError("Id", "Invalid ID or Password");
				return View(viewModel);
			}
			return Json(new { success = true, message = $"Welcome, {student.Role}!" });
		}
	}
}
