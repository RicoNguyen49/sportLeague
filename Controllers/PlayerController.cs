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
    public class PlayerController : Controller
    {
        private readonly SportsContext _context;

        public PlayerController(SportsContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString, string sortOrder, int? page)
        {

            var players = _context.Players.Include(p => p.Team).AsQueryable();

            // Search filter
            if (!string.IsNullOrEmpty(searchString))
            {
                players = players.Where(p => p.FirstName.Contains(searchString) ||
                                              (p.Team != null && p.Team.Name.Contains(searchString)));
            }

            // Apply sorting
            switch (sortOrder)
            {
                case "name_desc":
                    players = players.OrderByDescending(p => p.FirstName);
                    break;
                case "Lname":
                    players = players.OrderBy(p => p.LastName);
                    break;
                case "Lname_desc":
                    players = players.OrderByDescending(p => p.LastName);
                    break;
                case "Team":
                    players = players.OrderBy(p => p.Team.Name);
                    break;
                case "team_desc":
                    players = players.OrderByDescending(p => p.Team.Name);
                    break;
                default:
                    players = players.OrderBy(p => p.FirstName);
                    break;
            }

            // Pagination
            int pageSize = 5; // Number of items per page
            int pageNumber = (page ?? 1); // Default to page 1 if no page parameter is passed

            // Use ToPagedList() for synchronous paging
            var pagedPlayers = players.ToPagedList(pageNumber, pageSize);

            // Pass search term and sort order to ViewData for persistence
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["FirstNameSortParm"] = sortOrder == "name_desc" ? "name_asc" : "name_desc";
            ViewData["TeamSortParm"] = sortOrder == "team_desc" ? "team_asc" : "team_desc";
            ViewData["LastNameSortParm"] = sortOrder == "Lname_desc" ? "Lname_asc" : "Lname_desc"; 



            return View(pagedPlayers);
        }

        /* GET: Player
        public async Task<IActionResult> Index()
        {
            var sportsContext = _context.Players.Include(p => p.Team);
            return View(await sportsContext.ToListAsync());
        }*/

        // GET: Player/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.PlayerId == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Player/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "Name");
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,FirstName,LastName,Position,Age,TeamId")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "Name", player.TeamId);
            return View(player);
        }

        // GET: Player/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "Name", player.TeamId);
            return View(player);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerId,FirstName,LastName,Position,Age,TeamId")] Player player)
        {
            if (id != player.PlayerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.PlayerId))
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
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "Name", player.TeamId);
            return View(player);
        }

        // GET: Player/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.PlayerId == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player != null)
            {
                _context.Players.Remove(player);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.PlayerId == id);
        }
    }
}
