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
    public class DetalleInscripcionesController : Controller
    {
        private readonly InscripcionesContext _context;

        public DetalleInscripcionesController(InscripcionesContext context)
        {
            _context = context;
        }


        // GET: DetalleInscripciones
        public async Task<IActionResult> IndexPorInscripcion(int? idinscripcion = 1)
        {
            var inscripcionesContext = _context.DetalleInscripciones.Include(d => d.Materia).ThenInclude(m => m.AnioCarrera).ThenInclude(a => a.Carrera).Where(d => d.InscripcionId.Equals(idinscripcion)).OrderBy(d => d.Materia.AnioCarreraId);
            ViewData["Inscripciones"] = new SelectList(_context.Inscripciones.Include(i => i.Alumno), "Id", "Inscripto", idinscripcion);
            ViewData["IdInscripcion"] = idinscripcion;
            return View(await inscripcionesContext.ToListAsync());
        }

        // GET: DetalleInscripcions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleInscripcion = await _context.DetalleInscripciones
                .Include(d => d.Inscripcion)
                .Include(d => d.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleInscripcion == null)
            {
                return NotFound();
            }

            return View(detalleInscripcion);
        }

        // GET: DetalleInscripciones/CreateConInscripcion
        public IActionResult CreateConInscripcion(int? idinscripcion = 1, int? idaniocarrera = null)
        {
            // armo la lista de inscripciones y selecciono la inscripción actual, al pasarle la variable idinscripcion
            ViewData["Inscripciones"] = new SelectList(_context.Inscripciones.Include(i => i.Alumno).Include(i=>i.Carrera), "Id", "Inscripto", idinscripcion);

            //obtengo el registro de la inscripción actual
            Inscripcion inscripcion = _context.Inscripciones.FirstOrDefault(i => i.Id == idinscripcion);

            // si no tengo definido un aniocarrera, busco el primer anio carrera(firstOrDefault()), es decir, los 2 signos de pregunta determinan que su codigo sgte solo se ejecute si la e´presion que tienen  a la izquierda es igual a null
            idaniocarrera ??= _context.AnioCarreras.Where(i => i.CarreraId == inscripcion.CarreraId).FirstOrDefault().Id;

            // armo la lista de amios de la carrera seleccionada, seleccionando el idaniocarrera
            ViewData["AniosCarreras"] = new SelectList(_context.AnioCarreras.Include(a => a.Carrera).Where(_i => _i.CarreraId == inscripcion.CarreraId), "Id", "AñoYCarrera", idaniocarrera);

            // almacenamos el idinscripcion para que se mantenga la misma en los diferentes create que ejecutemos
            ViewData["IdInscripcion"] = idinscripcion;

            // almacenamos el idaniocarrera para que se mantenga la misma en los diferentes create que ejecutemos
            ViewData["IdAnioCarrera"] = idaniocarrera;

            // armamos la lista de materias que pertenezca a aniocarrera
            ViewData["Materias"] = new SelectList(_context.Materias.Where(m => m.AnioCarreraId.Equals(idaniocarrera)), "Id", "Nombre");
            ViewData["DetallesInscripciones"] = _context.DetalleInscripciones.Include(d => d.Materia).ThenInclude(m => m.AnioCarrera).ThenInclude(a => a.Carrera).Where(d => d.InscripcionId.Equals(idinscripcion)).OrderBy(d => d.Materia.AnioCarreraId);
            return View();
        }

        // POST: DetalleInscripciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModalidadCursado,InscripcionId,MateriaId")] DetalleInscripcion detalleInscripcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleInscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexPorInscripcion));
            }
            ViewData["InscripcionId"] = new SelectList(_context.Inscripciones.Include(i => i.Alumno).Include(i => i.Carrera), "Id", "Inscripto", detalleInscripcion.InscripcionId);
            ViewData["MateriaId"] = new SelectList(_context.Materias, "Id", "Nombre", detalleInscripcion.MateriaId);
            return View(detalleInscripcion);
        }
        // POST: DetalleInscripciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConInscripcion([Bind("Id,ModalidadCursado,InscripcionId,MateriaId")] DetalleInscripcion detalleInscripcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleInscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexPorInscripcion), new { idinscripcion = detalleInscripcion.InscripcionId });
            }
            ViewData["InscripcionId"] = new SelectList(_context.Inscripciones.Include(i => i.Alumno), "Id", "Inscripto", detalleInscripcion.InscripcionId);
            ViewData["MateriaId"] = new SelectList(_context.Materias, "Id", "Nombre", detalleInscripcion.MateriaId);
            return View(detalleInscripcion);
        }

        // GET: DetalleInscripcions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleInscripcion = await _context.DetalleInscripciones.FindAsync(id);
            if (detalleInscripcion == null)
            {
                return NotFound();
            }
            ViewData["InscripcionId"] = new SelectList(_context.Inscripciones, "Id", "Id", detalleInscripcion.InscripcionId);
            ViewData["MateriaId"] = new SelectList(_context.Materias, "Id", "Id", detalleInscripcion.MateriaId);
            return View(detalleInscripcion);
        }

        // POST: DetalleInscripcions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modalidadcursado,InscripcionId,MateriaId")] DetalleInscripcion detalleInscripcion)
        {
            if (id != detalleInscripcion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleInscripcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleInscripcionExists(detalleInscripcion.Id))
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
            ViewData["InscripcionId"] = new SelectList(_context.Inscripciones, "Id", "Id", detalleInscripcion.InscripcionId);
            ViewData["MateriaId"] = new SelectList(_context.Materias, "Id", "Id", detalleInscripcion.MateriaId);
            return View(detalleInscripcion);
        }

        // GET: DetalleInscripcions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleInscripcion = await _context.DetalleInscripciones
                .Include(d => d.Inscripcion)
                .Include(d => d.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleInscripcion == null)
            {
                return NotFound();
            }

            return View(detalleInscripcion);
        }

        // POST: DetalleInscripcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleInscripcion = await _context.DetalleInscripciones.FindAsync(id);
            if (detalleInscripcion != null)
            {
                _context.DetalleInscripciones.Remove(detalleInscripcion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleInscripcionExists(int id)
        {
            return _context.DetalleInscripciones.Any(e => e.Id == id);
        }
    }
}
