using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using WebLanguageMulti.Models;

namespace WebLanguageMulti.Controllers
{
    public class RegisterViewsController : Controller
    {
        private readonly WebLanguageMultiContext _context;
        //private readonly IStringLocalizer<RegisterViewsController> _localizer;
        //private readonly ILogger<RegisterViewsController> _logger;

        public RegisterViewsController(WebLanguageMultiContext context)
        {
            //_localizer = localizer;
            //_logger = logger;
            _context = context;
        }

        // GET: RegisterViews
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegisterViews.ToListAsync());
        }

        // GET: RegisterViews/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerViews = await _context.RegisterViews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registerViews == null)
            {
                return NotFound();
            }

            return View(registerViews);
        }

        // GET: RegisterViews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegisterViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Age,Email")] RegisterViews registerViews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registerViews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registerViews);
        }

        // GET: RegisterViews/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerViews = await _context.RegisterViews.FindAsync(id);
            if (registerViews == null)
            {
                return NotFound();
            }
            return View(registerViews);
        }

        // POST: RegisterViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,Age,Email")] RegisterViews registerViews)
        {
            if (id != registerViews.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registerViews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterViewsExists(registerViews.Id))
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
            return View(registerViews);
        }

        // GET: RegisterViews/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerViews = await _context.RegisterViews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registerViews == null)
            {
                return NotFound();
            }

            return View(registerViews);
        }

        // POST: RegisterViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var registerViews = await _context.RegisterViews.FindAsync(id);
            _context.RegisterViews.Remove(registerViews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterViewsExists(string id)
        {
            return _context.RegisterViews.Any(e => e.Id == id);
        }
    }
}
