using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;
using Inscripciones.Models.Commons;

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
            var inscripcionesContext = _context.materias.Include(m => m.AnioCarrera).ThenInclude(a => a.Carrera);
            return View(await inscripcionesContext.ToListAsync());
        }

        public async Task<IActionResult> IndexPorAnio(int? idanio = 1)
        {

            ViewData["AniosCarreras"] = new SelectList(_context.anioscarreras.Include(a => a.Carrera), "Id", "AñoYCarrera");
            ViewData["IdAnio"] = idanio;

            var materias = await _context.materias.Include(m => m.AnioCarrera).ThenInclude(a => a.Carrera).Where(m => m.AnioCarreraId.Equals(idanio)).ToListAsync();
            ViewData["IdCarrera"] = materias.FirstOrDefault()?.AnioCarrera.CarreraId ?? 0;
            return View(materias);
        }

        // GET: Materias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.materias
                .Include(m => m.AnioCarrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // GET: Materias/Create
        public IActionResult Create()
        {
            ViewData["AniosCarreras"] = new SelectList(_context.anioscarreras.Include(a => a.Carrera), "Id", "AñoYCarrera");
            return View();
        }
        public IActionResult CreateConAnio(int? idanio)
        {
            ViewData["AniosCarreras"] = new SelectList(_context.anioscarreras.Include(a => a.Carrera), "Id", "AñoYCarrera", idanio);
            ViewData["IdAnio"] = idanio;
            return View();
        }

        // POST: Materias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,AnioCarreraId")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AniosCarreras"] = new SelectList(_context.anioscarreras.Include(a => a.Carrera), "Id", "AñoYCarrera", materia.AnioCarreraId);
            return View(materia);
        }

        // POST: Materias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConAnio([Bind("Id,Nombre,AnioCarreraId")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexPorAnio), new { idanio = materia.AnioCarreraId });
            }
            ViewData["AniosCarreras"] = new SelectList(_context.anioscarreras.Include(a => a.Carrera), "Id", "AñoYCarrera", materia.AnioCarreraId);
            return View(materia);
        }
        // GET: Materias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.materias.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }
            ViewData["AniosCarreras"] = new SelectList(_context.anioscarreras.Include(a => a.Carrera), "Id", "AñoYCarrera", materia.AnioCarreraId);
            return View(materia);
        }

        // POST: Materias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,AnioCarreraId")] Materia materia)
        {
            if (id != materia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaExists(materia.Id))
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
            ViewData["AniosCarreras"] = new SelectList(_context.anioscarreras.Include(a => a.Carrera), "Id", "AñoYCarrera", materia.AnioCarreraId);
            return View(materia);
        }

        // GET: Materias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.materias
                .Include(m => m.AnioCarrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materia = await _context.materias.FindAsync(id);
            if (materia != null)
            {
                _context.materias.Remove(materia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaExists(int id)
        {
            return _context.materias.Any(e => e.Id == id);
        }
    }
}