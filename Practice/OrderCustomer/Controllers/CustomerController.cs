using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.MicrosoftExtensions;
using OrderCustomer.DTOs;
using OrderCustomer.EF;

namespace OrderCustomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ShopDbContext _context, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _context.Customers.Include(s => s.Orders).ToList();
            var dtos = _mapper.Map<List<CustomerDTO>>(customers);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _context.Customers.Include(s => s.Orders).FirstOrDefault(c => c.CustomerId == id);
            var dto = _mapper.Map<CustomerDTO>(customer);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerCreateDTO customerCreateDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }   

            var customer = _mapper.Map<Customer>(customerCreateDTO);
            
            _context.Customers.Add(customer);
            _context.SaveChanges();
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerId }, customerDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, CustomerUpdateDTO customerUpdateDTO)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);

            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            customerUpdateDTO.CustomerId = id;
            _mapper.Map(customerUpdateDTO, customer);            
            _context.SaveChanges();

            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDTO);
        }

    }
}
