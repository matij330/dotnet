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
    public class OcenyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OcenyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Oceny
        public async Task<IActionResult> Index()
        {
            return View(await _context.Grades.ToListAsync());
        }

        // GET: Oceny/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentOceny = await _context.Grades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentOceny == null)
            {
                return NotFound();
            }

            return View(studentOceny);
        }

        // GET: Oceny/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oceny/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Grade")] StudentOceny studentOceny)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentOceny);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentOceny);
        }

        // GET: Oceny/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentOceny = await _context.Grades.FindAsync(id);
            if (studentOceny == null)
            {
                return NotFound();
            }
            return View(studentOceny);
        }

        // POST: Oceny/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Grade")] StudentOceny studentOceny)
        {
            if (id != studentOceny.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentOceny);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentOcenyExists(studentOceny.Id))
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
            return View(studentOceny);
        }

        // GET: Oceny/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentOceny = await _context.Grades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentOceny == null)
            {
                return NotFound();
            }

            return View(studentOceny);
        }

        // POST: Oceny/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentOceny = await _context.Grades.FindAsync(id);
            if (studentOceny != null)
            {
                _context.Grades.Remove(studentOceny);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentOcenyExists(int id)
        {
            return _context.Grades.Any(e => e.Id == id);
        }
    }
}
