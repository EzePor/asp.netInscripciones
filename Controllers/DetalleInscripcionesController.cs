using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;
using Inscripciones.Models.Inscripciones;

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
        public async Task<IActionResult> Index()
        {
            var inscripcionesContext = await _context.detallesinscripciones.Include(d => d.Inscripcion).ThenInclude(d => d.Alumno).Include(d => d.Materia).ToListAsync();


            return View(inscripcionesContext);
        }

        // GET: DetalleInscripciones
        public async Task<IActionResult> IndexPorInscripcion(int? idinscripcion = 1)
        {
            var inscripciones = _context.detallesinscripciones.Include(d => d.Materia).ThenInclude(m => m.AnioCarrera).ThenInclude(a => a.Carrera).Where(d => d.InscripcionId.Equals(idinscripcion)).OrderBy(d => d.Materia.AnioCarreraId);
            ViewData["Inscripciones"] = new SelectList(_context.inscripciones.Include(i => i.Alumno), "Id", "Inscripto", idinscripcion);
            ViewData["IdInscripcion"] = idinscripcion;
            return View(await inscripciones.ToListAsync());
        }

        // GET: DetalleInscripciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleInscripcion = await _context.detallesinscripciones
                .Include(d => d.Inscripcion).ThenInclude(d => d.Alumno)
                .Include(d => d.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleInscripcion == null)
            {
                return NotFound();
            }

            return View(detalleInscripcion);
        }

        // GET: DetalleInscripciones/Create
        public IActionResult Create()
        {
            ViewData["Inscripciones"] = new SelectList(_context.inscripciones.Include(i => i.Alumno), "Id", "Inscripto");
            ViewData["MateriaId"] = new SelectList(_context.materias, "Id", "Nombre");
            return View();
        }

        // GET: DetalleInscripciones/Create
        public IActionResult CreateConInscripcion(int? idinscripcion = 1, int? idaniocarrera = null)
        {
            ArmoDatosParaCreateConInscripcion(idinscripcion, idaniocarrera);
            return View();
        }

        private void ArmoDatosParaCreateConInscripcion(int? idinscripcion, int? idaniocarrera)
        {
            //armo la lista de inscripciones y selecciono la inscripción actual, al pasarle la variable idinscripción
            ViewData["Inscripciones"] = new SelectList(_context.inscripciones.Include(i => i.Alumno).Include(i => i.Carrera), "Id", "Inscripto", idinscripcion);

            //obtengo el registro de la inscripción actual
            Inscripcion inscripcion = _context.inscripciones.FirstOrDefault(i => i.Id == idinscripcion);

            //si no tengo definido un aniocarrera, busco el primer anio carrera(firstOrDefault()), es decir, los 2 signos de pregunta determinan que su código siguiente solo se ejecute si la expresión que tienen a la lizquierda es igual a null
            idaniocarrera ??= _context.anioscarreras.Where(i => i.CarreraId == inscripcion.CarreraId).FirstOrDefault().Id;

            //armo la lista de anios de la carrera seleccionada, seleccionando el idaniocarrera
            ViewData["AniosCarreras"] = new SelectList(_context.anioscarreras.Include(a => a.Carrera).Where(_i => _i.CarreraId == inscripcion.CarreraId), "Id", "AñoYCarrera", idaniocarrera);

            //almacenamos el idinscripción para que se mantenga la misma en los diferentes create que ejecutemos
            ViewData["IdInscripcion"] = idinscripcion;

            //almacenamos el idaniocarrera para que se mantenga el mismo en los diferentes create que ejecutemos
            ViewData["IdAnioCarrera"] = idaniocarrera;

            //armamos una lista de materias que pertenezca al aniocarrera seleccionado
            ViewData["Materias"] = new SelectList(_context.materias.Where(m => m.AnioCarreraId.Equals(idaniocarrera)), "Id", "Nombre");

            //enviamos la lista de los detalles de inscripción de la inscripción actual, para que se arme la tabla que las muestra mientras vamos cargando alguna nueva
            ViewData["DetallesInscripciones"] = _context.detallesinscripciones.Include(d => d.Materia).ThenInclude(m => m.AnioCarrera).ThenInclude(a => a.Carrera).Where(d => d.InscripcionId.Equals(idinscripcion)).OrderBy(d => d.Materia.AnioCarreraId);
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
            ViewData["InscripcionId"] = new SelectList(_context.inscripciones.Include(i => i.Alumno), "Id", "Inscripto", detalleInscripcion.InscripcionId);
            ViewData["MateriaId"] = new SelectList(_context.materias, "Id", "Nombre", detalleInscripcion.MateriaId);
            return View(detalleInscripcion);
        }
        // POST: DetalleInscripciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConInscripcion([Bind("Id,ModalidadCursado,InscripcionId,MateriaId")] DetalleInscripcion detalleInscripcion)
        {
            var detalleExistente = _context.detallesinscripciones.Where(d => d.InscripcionId.Equals(detalleInscripcion.InscripcionId) && d.MateriaId.Equals(detalleInscripcion.MateriaId)).FirstOrDefault();
            if (ModelState.IsValid && detalleExistente == null)
            {
                _context.Add(detalleInscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexPorInscripcion), new { idinscripcion = detalleInscripcion.InscripcionId });
            }
            ViewData["MensajeError"] = $"La materia {_context.materias.Where(m => m.Id.Equals(detalleInscripcion.MateriaId)).FirstOrDefault()?.Nombre} ya está cargada ";
            int idinscripcion = detalleInscripcion.InscripcionId;
            int? idaniocarrera = _context.materias.Where(m => m.Id.Equals(detalleInscripcion.MateriaId)).FirstOrDefault()?.AnioCarreraId;
            ArmoDatosParaCreateConInscripcion(idinscripcion, idaniocarrera);
            return View(detalleInscripcion);
        }

        // GET: DetalleInscripciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleInscripcion = await _context.detallesinscripciones.FindAsync(id);
            if (detalleInscripcion == null)
            {
                return NotFound();
            }
            ViewData["InscripcionId"] = new SelectList(_context.inscripciones.Include(i => i.Alumno), "Id", "Inscripto", detalleInscripcion.InscripcionId);
            ViewData["MateriaId"] = new SelectList(_context.materias, "Id", "Nombre", detalleInscripcion.MateriaId);
            return View(detalleInscripcion);
        }

        // POST: DetalleInscripciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModalidadCursado,InscripcionId,MateriaId")] DetalleInscripcion detalleInscripcion)
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
            ViewData["InscripcionId"] = new SelectList(_context.inscripciones.Include(i => i.Alumno), "Id", "Inscripto", detalleInscripcion.InscripcionId);
            ViewData["MateriaId"] = new SelectList(_context.materias, "Id", "Nombre", detalleInscripcion.MateriaId);
            return View(detalleInscripcion);
        }

        // GET: DetalleInscripciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleInscripcion = await _context.detallesinscripciones
                .Include(d => d.Inscripcion).ThenInclude(d => d.Alumno)
                .Include(d => d.Materia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleInscripcion == null)
            {
                return NotFound();
            }

            return View(detalleInscripcion);
        }

        // POST: DetalleInscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleInscripcion = await _context.detallesinscripciones.FindAsync(id);
            if (detalleInscripcion != null)
            {
                _context.detallesinscripciones.Remove(detalleInscripcion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleInscripcionExists(int id)
        {
            return _context.detallesinscripciones.Any(e => e.Id == id);
        }
    }
}