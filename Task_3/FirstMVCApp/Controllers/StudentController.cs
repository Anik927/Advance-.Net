using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class StudentController : Controller
    {


        public IActionResult Index()
        {
            ViewBag.Title = "Student List"; 
            ViewData["SubTitle"] = "Enrolled students this semester"; 
            var students = new List<string> { "Alice Rahman", "Bob Hasan", "Carol Akter", "David Khan" }; 
            return View(students);
        }

        public IActionResult Details(int id)
        {
            ViewBag.StudentID = id;
            return View();
        }

        public IActionResult About()
        {
            return Content("This is student module");
        }

    }
}
