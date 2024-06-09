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
    public class AnioCarrerasController : Controller
    {
        private readonly InscripcionesContext _context;

        public AnioCarrerasController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: AnioCarreras
        public async Task<IActionResult> Index()
        {
            var inscripcionesContext = _context.AnioCarreras.Include(a => a.Carrera);
            return View(await inscripcionesContext.ToListAsync());
        }

        // GET: AnioCarreras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anioCarrera = await _context.AnioCarreras
                .Include(a => a.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anioCarrera == null)
            {
                return NotFound();
            }

            return View(anioCarrera);
        }

        // GET: AnioCarreras/Create
        public IActionResult Create()
        {
            ViewData["Carreras"] = new SelectList(_context.Carreras, "Id", "Nombre");
            return View();
        }

        // POST: AnioCarreras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,CarreraId")] AnioCarrera anioCarrera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anioCarrera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "Id", "Id", anioCarrera.CarreraId);
            return View(anioCarrera);
        }

        // GET: AnioCarreras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anioCarrera = await _context.AnioCarreras.FindAsync(id);
            if (anioCarrera == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "Id", "Id", anioCarrera.CarreraId);
            return View(anioCarrera);
        }

        // POST: AnioCarreras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,CarreraId")] AnioCarrera anioCarrera)
        {
            if (id != anioCarrera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anioCarrera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnioCarreraExists(anioCarrera.Id))
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
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "Id", "Id", anioCarrera.CarreraId);
            return View(anioCarrera);
        }

        // GET: AnioCarreras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anioCarrera = await _context.AnioCarreras
                .Include(a => a.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anioCarrera == null)
            {
                return NotFound();
            }

            return View(anioCarrera);
        }

        // POST: AnioCarreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anioCarrera = await _context.AnioCarreras.FindAsync(id);
            if (anioCarrera != null)
            {
                _context.AnioCarreras.Remove(anioCarrera);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnioCarreraExists(int id)
        {
            return _context.AnioCarreras.Any(e => e.Id == id);
        }
    }
}
