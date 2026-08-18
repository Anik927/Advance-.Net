using Course_Management_System.EF;
using Microsoft.AspNetCore.Mvc;

namespace Course_Management_System.Controllers
{
    public class StudentsController(CMSDbContext _context) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
