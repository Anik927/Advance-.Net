//using FirstMVCApp.Models;
using FirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Student student)
        {
            // Check for duplicate student ID manually
            if (student.StudentId == "STU001") 
            {
                ModelState.AddModelError("StudentId", "Student ID STU001 is already registered");
            } 
            if (!ModelState.IsValid) 
            {
                return View(student); 
            } 
            ViewBag.Message = "Registration successful for " + student.Name; 
            return View("Success", student);

        }

    }
}
