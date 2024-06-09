using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;

namespace Inscripciones.Controllers
{
    public class MateriasController : Controller
    {
        private readonly InscripcionesContext _context;

        public MateriasController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: Materias
        public async Task<IActionResult> Index()
        {
            var inscripcionesContext = _context.Materias.Include(m => m.AnioCarrera);
            return View(await inscripcionesContext.ToListAsync());
        }

        // GET: Materias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materias = await _context.Materias
                .Include(m => m.AnioCarrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materias == null)
            {
                return NotFound();
            }

            return View(materias);
        }

        // GET: Materias/Create
        public IActionResult Create()
        {
            ViewData["AnioCarreraId"] = new SelectList(_context.AnioCarreras, "Id", "Nombre");
            return View();
        }

        // POST: Materias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,AnioCarreraId")] Materia materias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnioCarreraId"] = new SelectList(_context.AnioCarreras, "Id", "Nombre", materias.AnioCarreraId);
            return View(materias);
        }

        // GET: Materias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materias = await _context.Materias.FindAsync(id);
            if (materias == null)
            {
                return NotFound();
            }
            ViewData["AnioCarreraId"] = new SelectList(_context.AnioCarreras, "Id", "Nombre", materias.AnioCarreraId);
            return View(materias);
        }

        // POST: Materias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,AnioCarreraId")] Materia materias)
        {
            if (id != materias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriasExists(materias.Id))
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
            ViewData["AnioCarreraId"] = new SelectList(_context.AnioCarreras, "Id", "Nombre", materias.AnioCarreraId);
            return View(materias);
        }

        // GET: Materias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materias = await _context.Materias
                .Include(m => m.AnioCarrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materias == null)
            {
                return NotFound();
            }

            return View(materias);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materias = await _context.Materias.FindAsync(id);
            if (materias != null)
            {
                _context.Materias.Remove(materias);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriasExists(int id)
        {
            return _context.Materias.Any(e => e.Id == id);
        }
    }
}
