using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderCustomer.DTOs;
using OrderCustomer.EF;

namespace OrderCustomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(ShopDbContext _context, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _context.Orders.Include(o => o.Customer).ToList();
            var dtos = _mapper.Map<List<OrderDTO>>(orders);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _context.Orders.Include(o => o.Customer).FirstOrDefault(o => o.OrderId == id);
            var dto = _mapper.Map<OrderDTO>(order);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }
    }
}
