using LabFinal01_53728.EF;
using Microsoft.AspNetCore.Mvc;

namespace LabFinal01_53728.Controllers
{
    public class EmployeeController(DeptDbContext _context) : Controller
    {
        public IActionResult List()
        {
            List<Employee> employees = _context.Employees.ToList();

			var Em = new CookieOptions
			{
				Expires = DateTime.Now.AddDays(7),
				HttpOnly = true,
				Secure = true
			};

			var prevValue = Request.Cookies["ECount"];
			
			int count = 0;

			if (!string.IsNullOrEmpty(prevValue))
			{
				int.TryParse(prevValue,out count);
			}

			count++;

			Response.Cookies.Append("ECount", count.ToString(), Em);
            
			ViewBag.Emm = count;

            return View(employees);
        }
    }
}
