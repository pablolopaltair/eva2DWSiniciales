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
    public class EvaTchNotasEvaluacionsController : Controller
    {
        private readonly BdEvaluacionContext _context;

        public EvaTchNotasEvaluacionsController(BdEvaluacionContext context)
        {
            _context = context;
        }

        // GET: EvaTchNotasEvaluacions
        public async Task<IActionResult> Index()
        {
            var bdEvaluacionContext = _context.EvaTchNotasEvaluacions.Include(e => e.CodEvaluacionNavigation);
            return View(await bdEvaluacionContext.ToListAsync());
        }

        // GET: EvaTchNotasEvaluacions/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.EvaTchNotasEvaluacions == null)
            {
                return NotFound();
            }

            var evaTchNotasEvaluacion = await _context.EvaTchNotasEvaluacions
                .Include(e => e.CodEvaluacionNavigation)
                .FirstOrDefaultAsync(m => m.IdNotaEvaluacion == id);
            if (evaTchNotasEvaluacion == null)
            {
                return NotFound();
            }

            return View(evaTchNotasEvaluacion);
        }
     
        // GET: EvaTchNotasEvaluacions/Create
        public IActionResult Create()
        {
            ViewData["CodEvaluacion"] = new SelectList(_context.EvaCatEvaluacions, "CodEvaluacion", "CodEvaluacion");
            return View();
        }

        // POST: EvaTchNotasEvaluacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MdUuid,MdDch,IdNotaEvaluacion,CodAlumno,NotaEvaluacion,CodEvaluacion")] EvaTchNotasEvaluacion evaTchNotasEvaluacion)
        {
            
            
                _context.Add(evaTchNotasEvaluacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["CodEvaluacion"] = new SelectList(_context.EvaCatEvaluacions, "CodEvaluacion", "CodEvaluacion", evaTchNotasEvaluacion.CodEvaluacion);
            return View(evaTchNotasEvaluacion);
        }

        // GET: EvaTchNotasEvaluacions/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.EvaTchNotasEvaluacions == null)
            {
                return NotFound();
            }

            var evaTchNotasEvaluacion = await _context.EvaTchNotasEvaluacions.FindAsync(id);
            if (evaTchNotasEvaluacion == null)
            {
                return NotFound();
            }
            ViewData["CodEvaluacion"] = new SelectList(_context.EvaCatEvaluacions, "CodEvaluacion", "CodEvaluacion", evaTchNotasEvaluacion.CodEvaluacion);
            return View(evaTchNotasEvaluacion);
        }

        // POST: EvaTchNotasEvaluacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MdUuid,MdDch,IdNotaEvaluacion,CodAlumno,NotaEvaluacion,CodEvaluacion")] EvaTchNotasEvaluacion evaTchNotasEvaluacion)
        {
            if (id != evaTchNotasEvaluacion.IdNotaEvaluacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaTchNotasEvaluacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaTchNotasEvaluacionExists(evaTchNotasEvaluacion.IdNotaEvaluacion))
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
            ViewData["CodEvaluacion"] = new SelectList(_context.EvaCatEvaluacions, "CodEvaluacion", "CodEvaluacion", evaTchNotasEvaluacion.CodEvaluacion);
            return View(evaTchNotasEvaluacion);
        }

        // GET: EvaTchNotasEvaluacions/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.EvaTchNotasEvaluacions == null)
            {
                return NotFound();
            }

            var evaTchNotasEvaluacion = await _context.EvaTchNotasEvaluacions
                .Include(e => e.CodEvaluacionNavigation)
                .FirstOrDefaultAsync(m => m.IdNotaEvaluacion == id);
            if (evaTchNotasEvaluacion == null)
            {
                return NotFound();
            }

            return View(evaTchNotasEvaluacion);
        }

        // POST: EvaTchNotasEvaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.EvaTchNotasEvaluacions == null)
            {
                return Problem("Entity set 'BdEvaluacionContext.EvaTchNotasEvaluacions'  is null.");
            }
            var evaTchNotasEvaluacion = await _context.EvaTchNotasEvaluacions.FindAsync(id);
            if (evaTchNotasEvaluacion != null)
            {
                _context.EvaTchNotasEvaluacions.Remove(evaTchNotasEvaluacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaTchNotasEvaluacionExists(long id)
        {
          return _context.EvaTchNotasEvaluacions.Any(e => e.IdNotaEvaluacion == id);
        }
    }
}
