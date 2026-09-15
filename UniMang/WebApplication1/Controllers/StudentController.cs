using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.NativeInterop;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.DTOs;
using WebApplication1.Entity;

namespace WebApplication1.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class StudentController(UniMContext context, IMapper mapper) : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Count") == null)
            {
                HttpContext.Session.SetInt32("Count", 0);
            }
            else
            {
                int count = HttpContext.Session.GetInt32("Count").Value;
                HttpContext.Session.SetInt32("Count", count + 1);
            }

            var cookieoptions = new CookieOptions
            {
                //Expires = DateTime.Now.AddMinutes(30),
                HttpOnly = true,
                IsEssential = true,
                Secure = true
            };

            Response.Cookies.Append("LastVisit", DateTime.Now.ToString(), cookieoptions);
            if(Request.Cookies.ContainsKey("VisitCount"))
            {
                int visitCount = int.Parse(Request.Cookies["VisitCount"]);
                visitCount++;
                Response.Cookies.Append("VisitCount", visitCount.ToString(), cookieoptions);
            }
            else
            {
                Response.Cookies.Append("VisitCount", "1", cookieoptions);
            }
            


            var students = context.Students.Include(s => s.Course).ToList();
            var studentDTOs = mapper.Map<List<StudentDTO>>(students);
            return View(studentDTOs);
        }

        public IActionResult Search(string searchName)
        {
            HttpContext.Session.SetString("searchName", searchName ?? "");
            if (!searchName.IsNullOrEmpty()) 
            {
                var studentss = context.Students.Include(s => s.Course)
                    .Where(s => s.Name.Contains(searchName))
                    .ToList();
                return View("Index",studentss);              
            }
            else
            {       
                var students = context.Students.Include(s => s.Course).ToList();
                return View("Index",students);
            }
        }

        [HttpGet,Authorize(Roles="Admin")]
        public IActionResult Create()
        {
            ViewBag.Courses = context.Courses.ToList(); 
            return View();
        }

        [HttpPost, Authorize(Roles ="Admin")]
        public IActionResult Create(StudentCreateDTO studentCreateDTO)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Courses = context.Courses.ToList();
                return View(studentCreateDTO);
            }

            var student = mapper.Map<Student>(studentCreateDTO);

            if(context.Students.Any(s=> s.Email == student.Email))
            {
                ModelState.AddModelError("Email", "Email address is already in use.");
                ViewBag.Courses = context.Courses.ToList();
                return View(studentCreateDTO);
            }   

            if(student.DateOfBirth > DateTime.Now)
            {
                ModelState.AddModelError("DateOfBirth", "Date of birth cannot be in the future.");
                ViewBag.Courses = context.Courses.ToList();
                return View(studentCreateDTO);
            }

            context.Students.Add(student);
            context.SaveChanges();
            
            return RedirectToAction("Index");

        }

        [HttpGet, Authorize(Roles ="Admin")]
        public IActionResult Update(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            var studentUpdateDTO = mapper.Map<StudentUpdateDTO>(student);
            ViewBag.Courses = context.Courses.ToList();
            return View(studentUpdateDTO);  
        }

        [HttpPost, Authorize(Roles ="Admin")]
        public IActionResult Update(StudentUpdateDTO studentUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Courses = context.Courses.ToList();
                return View(studentUpdateDTO);
            }
            var student = mapper.Map<Student>(studentUpdateDTO);
            if (context.Students.Any(s => s.Email == student.Email && s.Id != student.Id))
            {
                ModelState.AddModelError("Email", "Email address is already in use.");
                ViewBag.Courses = context.Courses.ToList();
                return View(studentUpdateDTO);
            }
            if (student.DateOfBirth > DateTime.Now)
            {
                ModelState.AddModelError("DateOfBirth", "Date of birth cannot be in the future.");
                ViewBag.Courses = context.Courses.ToList();
                return View(studentUpdateDTO);
            }
            context.Students.Update(student);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        
        [HttpGet, Authorize(Roles ="Admin")]
        public IActionResult Delete(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        }
}
