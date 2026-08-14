using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Entities;

namespace WebApplication1.Controllers
{
    public class ProductController(CompanyDbContext _context) : Controller
    {
        public IActionResult Index()
        {
            List<Product> data = _context.Products.ToList();

            return View(data);
        }
    

    [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

    [HttpPost]
    public IActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(product);
    }

    public IActionResult Delete(int pid)
    {
        var product = _context.Products.Find(pid);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    }
}
