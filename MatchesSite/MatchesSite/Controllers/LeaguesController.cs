using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatchesSite.Models;
using Microsoft.AspNetCore.Authorization;

namespace MatchesSite.Controllers
{
	[Authorize(Roles = "Admin")]
	public class LeaguesController : Controller
    {
        private readonly MatchesDatabaseContext _context;

        public LeaguesController(MatchesDatabaseContext context)
        {
            _context = context;
        }

        // GET: Leagues
        public async Task<IActionResult> Index()
        {
            var matchesDatabaseContext = _context.Leagues.Include(l => l.CountryNavigation);
            return View(await matchesDatabaseContext.ToListAsync());
        }

        // GET: Leagues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leagues = await _context.Leagues
                .Include(l => l.CountryNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leagues == null)
            {
                return NotFound();
            }

            return View(leagues);
        }

        // GET: Leagues/Create
        public IActionResult Create()
        {
            ViewData["Country"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: Leagues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Code,Country")] Leagues leagues)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leagues);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Country"] = new SelectList(_context.Countries, "Id", "Name", leagues.Country);
            return View(leagues);
        }

        // GET: Leagues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leagues = await _context.Leagues.FindAsync(id);
            if (leagues == null)
            {
                return NotFound();
            }
            ViewData["Country"] = new SelectList(_context.Countries, "Id", "Name", leagues.Country);
            return View(leagues);
        }

        // POST: Leagues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Code,Country")] Leagues leagues)
        {
            if (id != leagues.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leagues);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaguesExists(leagues.Id))
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
            ViewData["Country"] = new SelectList(_context.Countries, "Id", "Name", leagues.Country);
            return View(leagues);
        }

        // GET: Leagues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leagues = await _context.Leagues
                .Include(l => l.CountryNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leagues == null)
            {
                return NotFound();
            }

            return View(leagues);
        }

        // POST: Leagues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leagues = await _context.Leagues.FindAsync(id);
            _context.Leagues.Remove(leagues);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaguesExists(int id)
        {
            return _context.Leagues.Any(e => e.Id == id);
        }
    }
}
