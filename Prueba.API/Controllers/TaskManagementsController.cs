using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.API.Data;
using Prueba.API.Data.Entities;

namespace Prueba.API.Controllers
{
    public class TaskManagementsController : Controller
    {
        private readonly DataContext _context;

        public TaskManagementsController(DataContext context)
        {
            _context = context;
        }

        // GET: TaskManagements
        public async Task<IActionResult> Index()
        {
            return _context.TaskManagements != null ?
                        View(await _context.TaskManagements.ToListAsync()) :
                        Problem("No existen tareas registradas");
        }

        // GET: TaskManagements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TaskManagements == null)
            {
                return NotFound();
            }

            TaskManagement? taskManagement = await _context.TaskManagements
                .FirstOrDefaultAsync(m => m.Id == id);
            return taskManagement == null ? NotFound() : View(taskManagement);
        }

        // GET: TaskManagements/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskName,Description,ExpirationDate,IsComplete")] TaskManagement taskManagement)
        {
            if (ModelState.IsValid)
            {
                _ = _context.Add(taskManagement);
                _ = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskManagement);
        }

        // GET: TaskManagements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TaskManagements == null)
            {
                return NotFound();
            }

            TaskManagement? taskManagement = await _context.TaskManagements.FindAsync(id);
            return taskManagement == null ? NotFound() : View(taskManagement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskName,Description,ExpirationDate,IsComplete")] TaskManagement taskManagement)
        {
            if (id != taskManagement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = _context.Update(taskManagement);
                    _ = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskManagementExists(taskManagement.Id))
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
            return View(taskManagement);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TaskManagements == null)
            {
                return NotFound();
            }

            TaskManagement? taskManagement = await _context.TaskManagements
                .FirstOrDefaultAsync(m => m.Id == id);
            return taskManagement == null ? NotFound() : View(taskManagement);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TaskManagements == null)
            {
                return Problem("Entity set 'DataContext.TaskManagements'  is null.");
            }
            TaskManagement? taskManagement = await _context.TaskManagements.FindAsync(id);
            if (taskManagement != null)
            {
                _ = _context.TaskManagements.Remove(taskManagement);
            }

            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskManagementExists(int id)
        {
            return (_context.TaskManagements?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
