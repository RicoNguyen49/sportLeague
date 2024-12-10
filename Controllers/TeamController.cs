using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sportLeague.Models;
using X.PagedList;
using X.PagedList.Extensions;

namespace sportLeague.Controllers
{
    public class TeamController : Controller
    {
        private readonly SportsContext _context;

        public TeamController(SportsContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString, string sortOrder, int? page)
        {
            var teams = _context.Teams.Include(t => t.League).AsQueryable();


            // Apply search filter if search string is provided
            if (!string.IsNullOrEmpty(searchString))
            {
                teams = teams.Where(t => t.Name.Contains(searchString) || t.City.Contains(searchString));
            }

            // Apply sorting
            switch (sortOrder)
            {
                case "name_desc":
                    teams = teams.OrderByDescending(t => t.Name);
                    break;
                case "city":
                    teams = teams.OrderBy(t => t.City);
                    break;
                case "city_desc":
                    teams = teams.OrderByDescending(t => t.City); 
                    break;
                case "league_desc":
                    teams = teams.OrderByDescending(t => t.League); 
                    break;
                case "league":
                    teams = teams.OrderBy(t => t.League);
                    break;
                default:
                    teams = teams.OrderBy(t => t.Name);
                    break;
            }

            // Pagination
            int pageSize = 5; // Number of items per page
            int pageNumber = (page ?? 1); // Default to page 1 if no page parameter is passed

            // Use ToPagedList() for synchronous paging
            var pagedTeams = teams.ToPagedList(pageNumber, pageSize);

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = sortOrder == "name_desc" ? "name_asc" : "name_desc";
            ViewData["citySortParm"] = sortOrder == "city_desc" ? "city_asc" : "city_desc";
            ViewData["leagueSortParm"] = sortOrder == "league_desc" ? "league_asc" : "league_desc"; 


            return View(pagedTeams);
        }

        // GET: Team
      /*ublic async Task<IActionResult> Index()
        {
            var sportsContext = _context.Teams.Include(t => t.League);
            return View(await sportsContext.ToListAsync());
        }*/

        // GET: Team/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.League)
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Team/Create
        public IActionResult Create()
        {
            ViewData["LeagueId"] = new SelectList(_context.Leagues, "LeagueId", "Name");
            return View();
        }

        // POST: Team/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamId,Name,City,YearEstablished,LeagueId")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeagueId"] = new SelectList(_context.Leagues, "LeagueId", "Name", team.LeagueId);
            return View(team);
        }

        // GET: Team/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            ViewData["LeagueId"] = new SelectList(_context.Leagues, "LeagueId", "Name", team.LeagueId);
            return View(team);
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamId,Name,City,YearEstablished,LeagueId")] Team team)
        {
            if (id != team.TeamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.TeamId))
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
            ViewData["LeagueId"] = new SelectList(_context.Leagues, "LeagueId", "Name", team.LeagueId);
            return View(team);
        }

        // GET: Team/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.League)
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamId == id);
        }
    }
}
