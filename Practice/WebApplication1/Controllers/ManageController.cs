using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.EF;

namespace WebApplication1.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ManageController(CMSDbContext _context) : Controller
    {
		
		
		public IActionResult Students()
		{
			var students = _context.Students
				.Include(s => s.User)
				.Include(s => s.Department)
				.ToList();

			return View(students);
		}

		public IActionResult CreateStudent()
		{
			var student = new Student { User = new User() };
			return View(student);
		}

		[HttpPost]
		public IActionResult CreateStudent(Student student)
		{
			if (!ModelState.IsValid)
			{
				return View(student);
			}

			var departmentExists = _context.Departments.Any(d => d.Id == student.DepartmentId);
			if (!departmentExists)
			{
				ModelState.AddModelError("DepartmentId", "That department does not exist.");
				return View(student);
			}

			try
			{
				_context.Students.Add(student);
				_context.SaveChanges();
			}
			catch (DbUpdateException)
			{
				ModelState.AddModelError("", "Could not save student — please check your input.");
				return View(student);
			}
			return RedirectToAction("Students");
		}

		public IActionResult DeleteStudent(int id)
		{
			var student = _context.Students.Find(id);
			var user = _context.Users.Find(id);
			if (student == null|| user == null)
			{
				return NotFound();
			}

			_context.Users.Remove(user);
			//_context.Students.Remove(student);
			_context.SaveChanges();

			return RedirectToAction("Students");
		}

		public IActionResult EditStudent(int id)
		{
			var student = _context.Students.Find(id);
			var user = _context.Users.Find(id);
			if (student == null|| user == null)
			{
				return NotFound();
			}
			student.User = user;
			return View("CreateStudent", student);
		}

		[HttpPost]
		public IActionResult EditStudent(Student student)
		{
			if (!ModelState.IsValid)
			{
				return View("CreateStudent", student);
			}

			var oldStudent = _context.Students.Find(student.Id);
			var oldUser = _context.Users.Find(student.Id);

			var departmentExists = _context.Departments.Any(d => d.Id == student.DepartmentId);
			if (!departmentExists)
			{
				ModelState.AddModelError("DepartmentId", "That department does not exist.");
				return View("CreateStudent", student);
			}

			try
			{
				oldStudent.SemesterNumber = student.SemesterNumber;
				oldStudent.DepartmentId = student.DepartmentId;

				oldUser.Name = student.User.Name;
				oldUser.Password = student.User.Password;
				oldUser.Age = student.User.Age;
				oldUser.BloodGroup = student.User.BloodGroup;

				_context.SaveChanges();
			}
			catch (DbUpdateException)
			{
				ModelState.AddModelError("", "Could not save student — please check your input.");
				return View("CreateStudent", student);
			}
			return RedirectToAction("Students");
		}

		public IActionResult Departments()
        { 
            var departments = _context.Departments.ToList();
			return View(departments);
		}

        public IActionResult CreateDepartment()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateDepartment(Department department)
		{
			if (!ModelState.IsValid)
			{
				return View(department);
			}

			_context.Departments.Add(department);
			_context.SaveChanges();

			return RedirectToAction("Departments");

		}

		public IActionResult DeleteDepartment(int id)
		{
			var department = _context.Departments.Find(id);
			if (department == null)
			{
				return NotFound();
			}

			_context.Departments.Remove(department);
			_context.SaveChanges();

			return RedirectToAction("Departments");
		}

		public IActionResult EditDepartment(int id)
		{
			var department = _context.Departments.Find(id);
			if (department == null)
			{
				return NotFound();
			}
			return View(department);
		}

		[HttpPost]
		public IActionResult EditDepartment(Department department)
		{
			if (!ModelState.IsValid)
			{
				return View(department);
			}

			_context.Departments.Update(department);
			_context.SaveChanges();

			return RedirectToAction("Departments");
		}


	}
}
