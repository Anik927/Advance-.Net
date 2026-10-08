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
    public class BatchController(CourseManegmentContext context, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var batches = context.Batches.Include(d => d.Course).ToList();
            var batchDTOs = mapper.Map<List<BatchDTO>>(batches);
            return Ok(batchDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var batch = context.Batches.Include(d => d.Course).FirstOrDefault(b => b.Id == id);
            if (batch == null)
            {
                return NotFound();
            }
            var batchDTO = mapper.Map<BatchDTO>(batch);
            return Ok(batchDTO);
        }

        [HttpPost]
        public IActionResult Create(BatchCreateDTO batchCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var course = context.Courses.FirstOrDefault(c => c.Id == batchCreateDTO.CourseId);
            if (course == null)
            {
                return BadRequest("Invalid CourseId");
            }
            var batch = mapper.Map<Batch>(batchCreateDTO);
            context.Batches.Add(batch);
            context.SaveChanges();
            var batchDTO = mapper.Map<BatchDTO>(batch);
            return CreatedAtAction(nameof(GetById), new { id = batch.Id }, batchDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BatchUpdateDTO batchUpdateDTO)
        {

            var batch = context.Batches.Include(d => d.Course).FirstOrDefault(b => b.Id == id);
            if (batch == null)
            {
                return NotFound();
            }

            if (batchUpdateDTO.CourseId != batch.CourseId)
            {
                var course = context.Courses.FirstOrDefault(c => c.Id == batchUpdateDTO.CourseId);
                if (course == null)
                {
                    return BadRequest("Invalid CourseId");
                }
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            mapper.Map(batchUpdateDTO, batch);
            context.SaveChanges();

            var batchDTO = mapper.Map<BatchDTO>(batch);
            return Ok(batchDTO);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var batch = context.Batches.FirstOrDefault(b => b.Id == id);
            if (batch == null)
            {
                return NotFound();
            }
            context.Batches.Remove(batch);
            context.SaveChanges();
            return NoContent();
        }

    }
}
