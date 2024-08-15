using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models.Commons;
using Inscripciones.Models;

namespace Inscripciones.ApiControllers.Commons
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiIncriptoCarrerasController : ControllerBase
    {
        private readonly InscripcionesContext _context;

        public ApiIncriptoCarrerasController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: api/ApiIncriptoCarreras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InscriptoCarrera>>> GetIncriptoCarrera()
        {
            return await _context.inscriptoscarreras.ToListAsync();
        }

        // GET: api/ApiIncriptoCarreras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InscriptoCarrera>> GetIncriptoCarrera(int id)
        {
            var incriptoCarrera = await _context.inscriptoscarreras.FindAsync(id);

            if (incriptoCarrera == null)
            {
                return NotFound();
            }

            return incriptoCarrera;
        }

        // PUT: api/ApiIncriptoCarreras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncriptoCarrera(int id, InscriptoCarrera incriptoCarrera)
        {
            if (id != incriptoCarrera.Id)
            {
                return BadRequest();
            }

            _context.Entry(incriptoCarrera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncriptoCarreraExists(id))
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

        // POST: api/ApiIncriptoCarreras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InscriptoCarrera>> PostIncriptoCarrera(InscriptoCarrera incriptoCarrera)
        {
            _context.inscriptoscarreras.Add(incriptoCarrera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncriptoCarrera", new { id = incriptoCarrera.Id }, incriptoCarrera);
        }

        // DELETE: api/ApiIncriptoCarreras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncriptoCarrera(int id)
        {
            var incriptoCarrera = await _context.inscriptoscarreras.FindAsync(id);
            if (incriptoCarrera == null)
            {
                return NotFound();
            }
            incriptoCarrera.Eliminado = true;
            _context.inscriptoscarreras.Update(incriptoCarrera);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncriptoCarreraExists(int id)
        {
            return _context.inscriptoscarreras.Any(e => e.Id == id);
        }
    }
}
