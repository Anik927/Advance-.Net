using LabFinal2_53728.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabFinal2_53728.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(RetailDbContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = context.Products.ToList();
            return Ok(products);
        }
    }
}
