using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatchesSite.Models;

namespace MatchesSite.Controllers
{
    public class OpportunitiesController : Controller
    {
        private readonly MatchesDatabaseContext _context;

        public OpportunitiesController(MatchesDatabaseContext context)
        {
            _context = context;
        }

        // GET: Opportunities
        public async Task<IActionResult> Index()
        {
			var matchesDatabaseContext = _context.Opportunities
										.Include(o => o.AwayNavigation)
										.Include(o => o.CountryNavigation)
										.Include(o => o.HomeNavigation)
										.Include(o => o.Id1Navigation)
										.Include(o => o.Id2Navigation)
										.Include(o => o.IdXNavigation)
										.Include(o => o.LeagueNavigation)
										.Include(o => o.Profits);
            return View(await matchesDatabaseContext.ToListAsync());
        }

        // GET: Opportunities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunities = await _context.Opportunities
                .Include(o => o.AwayNavigation)
                .Include(o => o.CountryNavigation)
                .Include(o => o.HomeNavigation)
                .Include(o => o.Id1Navigation)
                .Include(o => o.Id2Navigation)
                .Include(o => o.IdXNavigation)
                .Include(o => o.LeagueNavigation)
				.Include(o => o.Profits)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opportunities == null)
            {
                return NotFound();
            }

            return View(opportunities);
        }

        private bool OpportunitiesExists(int id)
        {
            return _context.Opportunities.Any(e => e.Id == id);
        }
    }
}
