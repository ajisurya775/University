using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models;
using X.PagedList.Extensions;

namespace University.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }
        // GET: StudentsController
        [HttpGet]
        public IActionResult Index(string keyword, int? page)
        {
            int pageSize = 5;
            int pageNumber = page ?? 1;

            var students = _context.Students.Include(e => e.Enrollments).AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                students = students.Where(s => s.LastName.Contains(keyword)
                                           || s.FirstMidName.Contains(keyword));
                ViewData["CurrentFilter"] = keyword;
            }

            students = students.OrderBy(s => s.ID);

            // return Json(students.ToList());


            return View(students.ToPagedList(pageNumber, pageSize));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
            .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
            .AsTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Store
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Store([Bind("EnrollmentDate,FirstMidName,LastName")] Student student)
        {

            if (ModelState.IsValid)
            {
                student.EnrollmentDate = DateTime.SpecifyKind(student.EnrollmentDate, DateTimeKind.Utc);

                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Create", student);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
            .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
            .AsTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            student.EnrollmentDate = DateTime.UtcNow;

            return View("Edit", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("ID,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            if (id != student.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    student.EnrollmentDate = DateTime.SpecifyKind(student.EnrollmentDate, DateTimeKind.Utc);
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Students.Any(e => e.ID == student.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View("Edit", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Destroy(int? id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Destroy), new { id = id, saveChangesError = true });
            }
        }

    }
}
