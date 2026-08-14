using FirstMVCApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly SchoolDbContext _context;

        public DepartmentController(SchoolDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }
    }
}