using API2.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(LibraryDbContext _context, IMapper _mapper) : ControllerBase
    {       

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _context.Books.ToList();
            var bookDTOs = _mapper.Map<List<BookDTO>>(books);
            return Ok(bookDTOs);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            var bookDTO = _mapper.Map<BookDTO>(book);
            return Ok(bookDTO);
        }

        [HttpPost]
        public IActionResult Create(BookCreateDTO bookCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = _mapper.Map<Book>(bookCreateDTO);
            book.InternalNotes = book.InternalNotes ?? "Default internal notes";
            _context.Books.Add(book);
            _context.SaveChanges();
            var bookDTO = _mapper.Map<BookDTO>(book);
            return CreatedAtAction(nameof(GetById), new { id = book.BookId }, bookDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BookUpdateDTO bookUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            _mapper.Map(bookUpdateDTO, book);
            _context.SaveChanges();
            return NoContent();
        }



    }
}
