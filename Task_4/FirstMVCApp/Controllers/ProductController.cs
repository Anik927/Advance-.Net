using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(string category, int id)
        {
            ViewBag.Category = category;
            ViewBag.Id = id;
            return View();
        }

    }
}
