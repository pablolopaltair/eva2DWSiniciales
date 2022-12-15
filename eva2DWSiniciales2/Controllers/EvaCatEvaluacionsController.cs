using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace eva2DWSiniciales2.Controllers
{
    public class EvaCatEvaluacionsController : Controller
    {
        private readonly BdEvaluacionContext _context;

        public EvaCatEvaluacionsController(BdEvaluacionContext context)
        {
            _context = context;
        }

        // GET: EvaCatEvaluacions
        public async Task<IActionResult> Index()
        {
              return View(await _context.EvaCatEvaluacions.ToListAsync());
        }

        // GET: EvaCatEvaluacions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.EvaCatEvaluacions == null)
            {
                return NotFound();
            }

            var evaCatEvaluacion = await _context.EvaCatEvaluacions
                .FirstOrDefaultAsync(m => m.CodEvaluacion == id);
            if (evaCatEvaluacion == null)
            {
                return NotFound();
            }

            return View(evaCatEvaluacion);
        }

        // GET: EvaCatEvaluacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EvaCatEvaluacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodEvaluacion,DescEvaluacion")] EvaCatEvaluacion evaCatEvaluacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaCatEvaluacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evaCatEvaluacion);
        }

        // GET: EvaCatEvaluacions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.EvaCatEvaluacions == null)
            {
                return NotFound();
            }

            var evaCatEvaluacion = await _context.EvaCatEvaluacions.FindAsync(id);
            if (evaCatEvaluacion == null)
            {
                return NotFound();
            }
            return View(evaCatEvaluacion);
        }

        // POST: EvaCatEvaluacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodEvaluacion,DescEvaluacion")] EvaCatEvaluacion evaCatEvaluacion)
        {
            if (id != evaCatEvaluacion.CodEvaluacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaCatEvaluacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaCatEvaluacionExists(evaCatEvaluacion.CodEvaluacion))
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
            return View(evaCatEvaluacion);
        }

        // GET: EvaCatEvaluacions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.EvaCatEvaluacions == null)
            {
                return NotFound();
            }

            var evaCatEvaluacion = await _context.EvaCatEvaluacions
                .FirstOrDefaultAsync(m => m.CodEvaluacion == id);
            if (evaCatEvaluacion == null)
            {
                return NotFound();
            }

            return View(evaCatEvaluacion);
        }

        // POST: EvaCatEvaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.EvaCatEvaluacions == null)
            {
                return Problem("Entity set 'BdEvaluacionContext.EvaCatEvaluacions'  is null.");
            }
            var evaCatEvaluacion = await _context.EvaCatEvaluacions.FindAsync(id);
            if (evaCatEvaluacion != null)
            {
                _context.EvaCatEvaluacions.Remove(evaCatEvaluacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaCatEvaluacionExists(string id)
        {
          return _context.EvaCatEvaluacions.Any(e => e.CodEvaluacion == id);
        }
    }
}
