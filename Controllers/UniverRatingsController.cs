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
    public class UniverRatingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UniverRatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UniverRatings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UniverRating.Include(u => u.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UniverRatings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UniverRating == null)
            {
                return NotFound();
            }

            var univerRating = await _context.UniverRating
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UniRatingId == id);
            if (univerRating == null)
            {
                return NotFound();
            }

            return View(univerRating);
        }

        // GET: UniverRatings/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
            return View();
        }

        // POST: UniverRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniRatingId,UserId,UniId,Reputation,Happiness,Safety,Opportunities,Facilities,Clubs,Internet,Location,Social,Food,Date,Comment,OverallRating")] UniverRating univerRating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(univerRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", univerRating.UserId);
            return View(univerRating);
        }

        // GET: UniverRatings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UniverRating == null)
            {
                return NotFound();
            }

            var univerRating = await _context.UniverRating.FindAsync(id);
            if (univerRating == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", univerRating.UserId);
            return View(univerRating);
        }

        // POST: UniverRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniRatingId,UserId,UniId,Reputation,Happiness,Safety,Opportunities,Facilities,Clubs,Internet,Location,Social,Food,Date,Comment,OverallRating")] UniverRating univerRating)
        {
            if (id != univerRating.UniRatingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(univerRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniverRatingExists(univerRating.UniRatingId))
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
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", univerRating.UserId);
            return View(univerRating);
        }

        // GET: UniverRatings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UniverRating == null)
            {
                return NotFound();
            }

            var univerRating = await _context.UniverRating
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UniRatingId == id);
            if (univerRating == null)
            {
                return NotFound();
            }

            return View(univerRating);
        }

        // POST: UniverRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UniverRating == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UniverRating'  is null.");
            }
            var univerRating = await _context.UniverRating.FindAsync(id);
            if (univerRating != null)
            {
                _context.UniverRating.Remove(univerRating);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniverRatingExists(int id)
        {
          return (_context.UniverRating?.Any(e => e.UniRatingId == id)).GetValueOrDefault();
        }
    }
}
