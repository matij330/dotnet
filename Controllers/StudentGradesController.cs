using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotnet.Data;
using dotnet.Models;

namespace dotnet.Controllers
{
    public class StudentGradesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentGradesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentGrades
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentGrades.Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentGrades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentGrades = await _context.StudentGrades
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.GradeID == id);
            if (studentGrades == null)
            {
                return NotFound();
            }

            return View(studentGrades);
        }

        // GET: StudentGrades/Create
        public IActionResult Create()
        {
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID");
            return View();
        }

        // POST: StudentGrades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GradeID,Grade,StudentID")] StudentGrades studentGrades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentGrades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID", studentGrades.StudentID);
            return View(studentGrades);
        }

        // GET: StudentGrades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentGrades = await _context.StudentGrades.FindAsync(id);
            if (studentGrades == null)
            {
                return NotFound();
            }
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID", studentGrades.StudentID);
            return View(studentGrades);
        }

        // POST: StudentGrades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GradeID,Grade,StudentID")] StudentGrades studentGrades)
        {
            if (id != studentGrades.GradeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentGrades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentGradesExists(studentGrades.GradeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "StudentID", studentGrades.StudentID);
            return View(studentGrades);
        }

        // GET: StudentGrades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentGrades = await _context.StudentGrades
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.GradeID == id);
            if (studentGrades == null)
            {
                return NotFound();
            }

            return View(studentGrades);
        }

        // POST: StudentGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentGrades = await _context.StudentGrades.FindAsync(id);
            if (studentGrades != null)
            {
                _context.StudentGrades.Remove(studentGrades);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentGradesExists(int id)
        {
            return _context.StudentGrades.Any(e => e.GradeID == id);
        }
    }
}
