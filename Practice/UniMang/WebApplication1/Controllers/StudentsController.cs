using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Entity;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController(UniMContext context, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = context.Students.Include(s => s.Course).ToList();
            var studentDTOs = mapper.Map<List<StudentDTO>>(students);
            return Ok(studentDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudents(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            var studentDTO = mapper.Map<StudentDTO>(student);
            return Ok(studentDTO);
        }
        
        [HttpPost]
        public IActionResult CreateStudent(StudentCreateDTO studentCreateDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }   
            var student = mapper.Map<Student>(studentCreateDTO);
            context.Students.Add(student);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetStudents), new { id = student.Id }, studentCreateDTO);
        }
    }
}
