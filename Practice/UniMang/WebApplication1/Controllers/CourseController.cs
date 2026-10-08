using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entity;

namespace WebApplication1.Controllers
{
    public class CourseController(UniMContext context) : Controller
    {
        public IActionResult Index()
        {
            var courses = context.Courses.ToList();
            return View(courses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
