using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRateApp2.Data;
using MyRateApp2.Models;

namespace MyRateApp2.Controllers
{
    public class ProfessorRatingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfessorRatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProfessorRatings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProfessorRating.Include(p => p.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProfessorRatings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProfessorRating == null)
            {
                return NotFound();
            }

            var professorRating = await _context.ProfessorRating
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProfessorRatingId == id);
            if (professorRating == null)
            {
                return NotFound();
            }

            return View(professorRating);
        }

        // GET: ProfessorRatings/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
            return View();
        }

        // POST: ProfessorRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessorRatingId,Awesome,Great,Awful,Good,Ok,Comments,Attendance,Grade,Textbook,Date,RatingQuality,RatingDificulty,WouldTakeAgain,ForCredit,UserId,ProfId")] ProfessorRating professorRating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professorRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", professorRating.UserId);
            return View(professorRating);
        }

        // GET: ProfessorRatings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProfessorRating == null)
            {
                return NotFound();
            }

            var professorRating = await _context.ProfessorRating.FindAsync(id);
            if (professorRating == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", professorRating.UserId);
            return View(professorRating);
        }

        // POST: ProfessorRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfessorRatingId,Awesome,Great,Awful,Good,Ok,Comments,Attendance,Grade,Textbook,Date,RatingQuality,RatingDificulty,WouldTakeAgain,ForCredit,UserId,ProfId")] ProfessorRating professorRating)
        {
            if (id != professorRating.ProfessorRatingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professorRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorRatingExists(professorRating.ProfessorRatingId))
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
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", professorRating.UserId);
            return View(professorRating);
        }

        // GET: ProfessorRatings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProfessorRating == null)
            {
                return NotFound();
            }

            var professorRating = await _context.ProfessorRating
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProfessorRatingId == id);
            if (professorRating == null)
            {
                return NotFound();
            }

            return View(professorRating);
        }

        // POST: ProfessorRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProfessorRating == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProfessorRating'  is null.");
            }
            var professorRating = await _context.ProfessorRating.FindAsync(id);
            if (professorRating != null)
            {
                _context.ProfessorRating.Remove(professorRating);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorRatingExists(int id)
        {
          return (_context.ProfessorRating?.Any(e => e.ProfessorRatingId == id)).GetValueOrDefault();
        }
    }
}
