using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models.MesasExamenes;
using Inscripciones.Models;
using Inscripciones.Models.Commons;

namespace Inscripciones.ApiControllers.MesasExamenes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTurnoExamenesController : ControllerBase
    {
        private readonly InscripcionesContext _context;

        public ApiTurnoExamenesController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: api/ApiTurnoExamenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TurnoExamen>>> GetTurnoExamen()
        {
            return await _context.turnosexamenes.ToListAsync();
        }

        // GET: api/ApiTurnoExamenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TurnoExamen>> GetTurnoExamen(int id)
        {
            var turnoExamen = await _context.turnosexamenes.FindAsync(id);

            if (turnoExamen == null)
            {
                return NotFound();
            }

            return turnoExamen;
        }

        // PUT: api/ApiTurnoExamenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurnoExamen(int id, TurnoExamen turnoExamen)
        {
            if (id != turnoExamen.Id)
            {
                return BadRequest();
            }

            _context.Entry(turnoExamen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurnoExamenExists(id))
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

        // POST: api/ApiTurnoExamenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TurnoExamen>> PostTurnoExamen(TurnoExamen turnoExamen)
        {
            _context.turnosexamenes.Add(turnoExamen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTurnoExamen", new { id = turnoExamen.Id }, turnoExamen);
        }

        // DELETE: api/ApiTurnoExamenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurnoExamen(int id)
        {
            var turnoExamen = await _context.turnosexamenes.FindAsync(id);
            if (turnoExamen == null)
            {
                return NotFound();
            }
            turnoExamen.Eliminado = true;
            _context.turnosexamenes.Update(turnoExamen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TurnoExamenExists(int id)
        {
            return _context.turnosexamenes.Any(e => e.Id == id);
        }
    }
}
