using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class StudentController : Controller
    {


        public IActionResult Index()
        {
            ViewBag.title = "Student List";
            ViewBag.Message = "Welcome to the student Module";
            return View();
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
