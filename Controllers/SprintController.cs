using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Models;

namespace TaskFlow.Controllers
{
    public class SprintController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SprintController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Show all sprints
        public async Task<IActionResult> Index()
        {
            var sprints = await _context.Sprints
                .Include(s => s.Tasks)
                .ToListAsync();
            return View(sprints);
        }

        // Show form to create sprint
        public IActionResult Create()
        {
            return View();
        }

        // Save new sprint
        [HttpPost]
        public async Task<IActionResult> Create(Sprint sprint)
        {
            if (ModelState.IsValid)
            {
                _context.Sprints.Add(sprint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sprint);
        }

        // Show sprint details with tasks
        public async Task<IActionResult> Details(int id)
        {
            var sprint = await _context.Sprints
                .Include(s => s.Tasks)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (sprint == null) return NotFound();
            return View(sprint);
        }

        // Edit sprint
        public async Task<IActionResult> Edit(int id)
        {
            var sprint = await _context.Sprints.FindAsync(id);
            if (sprint == null) return NotFound();
            return View(sprint);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Sprint sprint)
        {
            if (ModelState.IsValid)
            {
                _context.Sprints.Update(sprint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sprint);
        }

        // Delete sprint
        public async Task<IActionResult> Delete(int id)
        {
            var sprint = await _context.Sprints.FindAsync(id);
            if (sprint == null) return NotFound();
            _context.Sprints.Remove(sprint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}