using APIFinalTest.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFinalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController(APITestDbContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDoctors()
        {
            var doctors = context.Doctors.Include(d => d.Patients).ToList();
            return Ok(doctors);
        }

        [HttpPost]
        public IActionResult CreateDoctor(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Doctors.Add(doctor);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetDoctors), new { id = doctor.Id }, doctor);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = context.Doctors.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }
            context.Doctors.Remove(doctor);
            context.SaveChanges();
            return NoContent();
        }

    }
}
