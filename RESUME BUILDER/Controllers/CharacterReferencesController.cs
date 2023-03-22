using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RESUME_BUILDER.Models;

namespace RESUME_BUILDER.Controllers
{
    public class CharacterReferencesController : Controller
    {
        private readonly ResumeContext _context;

        public CharacterReferencesController(ResumeContext context)
        {
            _context = context;
        }

        // GET: CharacterReferences
        public async Task<IActionResult> Index()
        {
            var resumeContext = _context.CharacterReferences.Include(c => c.Student);
            return View(await resumeContext.ToListAsync());
        }

        // GET: CharacterReferences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CharacterReferences == null)
            {
                return NotFound();
            }

            var characterReference = await _context.CharacterReferences
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (characterReference == null)
            {
                return NotFound();
            }

            return View(characterReference);
        }

        // GET: CharacterReferences/Create
        public IActionResult Create()
        {
            var dropdown = new List<Dropdown>();
            var students = _context.Students.ToList();

            foreach (var item in students)
            {
                dropdown.Add(new Dropdown
                {
                    Id = item.Id,
                    Name = item.FirstName + " " + item.LastName

                });
            }
            ViewData["StudentId"] = new SelectList(dropdown, "Id", "Name");
            return View();
        }

        // POST: CharacterReferences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Job,Company,ContactNumber,StudentId")] CharacterReference characterReference)
        {
            if (ModelState.IsValid)
            {
                _context.Add(characterReference);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", characterReference.StudentId);
            return View(characterReference);
        }

        // GET: CharacterReferences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CharacterReferences == null)
            {
                return NotFound();
            }

            var characterReference = await _context.CharacterReferences.FindAsync(id);
            if (characterReference == null)
            {
                return NotFound();
            }
            var dropdown = new List<Dropdown>();
            var students = _context.Students.Where(x => x.Id == id).ToList();

            foreach (var item in students)
            {
                dropdown.Add(new Dropdown
                {
                    Id = item.Id,
                    Name = item.FirstName + " " + item.LastName

                });
            }
            ViewData["StudentId"] = new SelectList(dropdown, "Id", "Name");
            return View(characterReference);
        }

        // POST: CharacterReferences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Job,Company,ContactNumber,StudentId")] CharacterReference characterReference)
        {
            if (id != characterReference.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(characterReference);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterReferenceExists(characterReference.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", characterReference.StudentId);
            return View(characterReference);
        }

        // GET: CharacterReferences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CharacterReferences == null)
            {
                return NotFound();
            }

            var characterReference = await _context.CharacterReferences
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (characterReference == null)
            {
                return NotFound();
            }

            return View(characterReference);
        }

        // POST: CharacterReferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CharacterReferences == null)
            {
                return Problem("Entity set 'ResumeContext.CharacterReferences'  is null.");
            }
            var characterReference = await _context.CharacterReferences.FindAsync(id);
            if (characterReference != null)
            {
                _context.CharacterReferences.Remove(characterReference);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterReferenceExists(int id)
        {
          return (_context.CharacterReferences?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
