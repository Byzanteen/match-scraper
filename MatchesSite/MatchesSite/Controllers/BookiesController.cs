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
	public class BookiesController : Controller
    {
        private readonly MatchesDatabaseContext _context;

        public BookiesController(MatchesDatabaseContext context)
        {
            _context = context;
        }

		// GET: Bookies
		public async Task<IActionResult> Index()
        {
            return View(await _context.Bookies.ToListAsync());
        }

        // GET: Bookies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookies = await _context.Bookies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookies == null)
            {
                return NotFound();
            }

            return View(bookies);
        }

        // GET: Bookies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Link,ImageLink")] Bookies bookies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookies);
        }

        // GET: Bookies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookies = await _context.Bookies.FindAsync(id);
            if (bookies == null)
            {
                return NotFound();
            }
            return View(bookies);
        }

        // POST: Bookies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Link,ImageLink")] Bookies bookies)
        {
            if (id != bookies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookiesExists(bookies.Id))
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
            return View(bookies);
        }

        // GET: Bookies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookies = await _context.Bookies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookies == null)
            {
                return NotFound();
            }

            return View(bookies);
        }

        // POST: Bookies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookies = await _context.Bookies.FindAsync(id);
            _context.Bookies.Remove(bookies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookiesExists(int id)
        {
            return _context.Bookies.Any(e => e.Id == id);
        }
    }
}
