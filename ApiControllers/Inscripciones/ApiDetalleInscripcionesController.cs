using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models.Inscripciones;
using Inscripciones.Models;
using Inscripciones.Models.Commons;
using NuGet.DependencyResolver;


namespace Inscripciones.ApiControllers.Inscripciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDetalleInscripcionesController : ControllerBase
    {
        private readonly InscripcionesContext _context;

        public ApiDetalleInscripcionesController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: api/ApiDetalleInscripcions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleInscripcion>>> GetDetalleInscripciones([FromQuery] int? idInscripcion )
            
        {
            if( idInscripcion != null ) 
            {
                return await _context.detallesinscripciones.Include(m=> m.Materia).Where(d=> d.InscripcionId.Equals(idInscripcion)).ToListAsync();
            }
            return await _context.detallesinscripciones.ToListAsync();
        }

        // GET: api/ApiDetalleInscripcions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleInscripcion>> GetDetalleInscripcion(int id)
        {
            var detalleInscripcion = await _context.detallesinscripciones.FindAsync(id);

            if (detalleInscripcion == null)
            {
                return NotFound();
            }

            return detalleInscripcion;
        }

        // PUT: api/ApiDetalleInscripcions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleInscripcion(int id, DetalleInscripcion detalleInscripcion)
        {
            if (id != detalleInscripcion.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleInscripcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleInscripcionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApiDetalleInscripcions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleInscripcion>> PostDetalleInscripcion(DetalleInscripcion detalleInscripcion)
        {
            _context.detallesinscripciones.Add(detalleInscripcion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleInscripcion", new { id = detalleInscripcion.Id }, detalleInscripcion);
        }

        // DELETE: api/ApiDetalleInscripcions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleInscripcion(int id)
        {
            var detalleInscripcion = await _context.detallesinscripciones.FindAsync(id);
            if (detalleInscripcion == null)
            {
                return NotFound();
            }
            detalleInscripcion.Eliminado = true;
            _context.detallesinscripciones.Update(detalleInscripcion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleInscripcionExists(int id)
        {
            return _context.detallesinscripciones.Any(e => e.Id == id);
        }
    }
}
