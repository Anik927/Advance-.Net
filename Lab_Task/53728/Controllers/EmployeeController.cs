using _53728.Data;
using Microsoft.AspNetCore.Mvc;

namespace _53728.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly CompanyDbContext _context;

        public EmployeeController(CompanyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }
    }
}
