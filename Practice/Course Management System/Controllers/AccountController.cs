using Course_Management_System.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Course_Management_System.Controllers
{
    public class AccountController(CMSDbContext _context) : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ui = _context.Students.FirstOrDefault(e => e.StudentId == model.StudentId && e.Password == model.Password);
                if (ui == null)
                {
                    ModelState.AddModelError("StudentId", "Invalid StudentId or Password");
                    return View(model);

                }
                HttpContext.Session.SetInt32("Id",model.StudentId);
                return RedirectToAction("Index", "Home");
            }
            else
				return View(model);
		}

        //[HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login","Account");
        }

    }
}
