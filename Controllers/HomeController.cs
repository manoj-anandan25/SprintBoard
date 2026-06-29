using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Models;

namespace TaskFlow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalTasks = await _context.Tasks.CountAsync();
            ViewBag.TodoTasks = await _context.Tasks
                .CountAsync(t => t.Status == "ToDo");
            ViewBag.InProgressTasks = await _context.Tasks
                .CountAsync(t => t.Status == "InProgress");
            ViewBag.DoneTasks = await _context.Tasks
                .CountAsync(t => t.Status == "Done");
            ViewBag.TotalSprints = await _context.Sprints.CountAsync();
            ViewBag.ActiveSprints = await _context.Sprints
                .CountAsync(s => s.IsActive);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}