using ContosoUniTARgv23.Data;
using ContosoUniTARgv23.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniTARgv23.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController
            (
                SchoolContext context
            )
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _context.Students
                .ToListAsync();

            return View(result);
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
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes." +
                    "Try again, and if the problem persists " +
                    "see your system administrator");
            }

            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost (int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var studentToUpdate = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync<Student>(studentToUpdate, "", s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate)) ;
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {

                    ModelState.AddModelError("", "Unable to Save changes" + "Try again" + "see your system administrator");
                }

            }

            return View(studentToUpdate);
        }
    }
}
