using AutoMapper;
using FE53728API.Data;
using FE53728API.Data.Entities;
using FE53728API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FE53728API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(CourseManegmentContext context, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var courses = context.Courses.Include(s => s.Batches).ToList();
            var courseDTOs = mapper.Map<List<CourseDTO>>(courses);
            return Ok(courseDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var course = context.Courses.Include(s => s.Batches).FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            var courseDTO = mapper.Map<CourseDTO>(course);
            return Ok(courseDTO);
        }

        [HttpPost]
        public IActionResult Create(CourseCreateDTO courseCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var course = mapper.Map<Course>(courseCreateDTO);
            context.Courses.Add(course);
            context.SaveChanges();
            var courseDTO = mapper.Map<CourseDTO>(course);
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, courseDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CourseUpdateDTO courseUpdateDTO)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            mapper.Map(courseUpdateDTO, course);
            context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            context.Courses.Remove(course);
            context.SaveChanges();
            return NoContent();
        }


    }
}
