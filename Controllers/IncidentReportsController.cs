using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class IncidentReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncidentReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // List all incident reports
        public async Task<IActionResult> Index()
        {
            var reports = await _context.IncidentReports.ToListAsync();
            return View(reports);
        }

        // Display incident report creation form
        public IActionResult Create()
        {
            return View();
        }

        // Process incident report creation form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Location,DateReported,Status,AssignedTeam,PriorityLevel")] IncidentReport report)
        {
            if (ModelState.IsValid)
            {
                _context.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }

        // View incident report details
        public async Task<IActionResult> Details(int id)
        {
            var report = await _context.IncidentReports.FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        // Edit an incident report
        public async Task<IActionResult> Edit(int id)
        {
            var report = await _context.IncidentReports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Location,DateReported,Status,AssignedTeam,PriorityLevel")] IncidentReport report)
        {
            if (id != report.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.IncidentReports.Any(e => e.Id == id))
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
            return View(report);
        }

        // Delete an incident report
        public async Task<IActionResult> Delete(int id)
        {
            var report = await _context.IncidentReports.FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var report = await _context.IncidentReports.FindAsync(id);
            _context.IncidentReports.Remove(report);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
