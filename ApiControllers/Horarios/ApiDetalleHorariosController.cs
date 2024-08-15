using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models.Horarios;
using Inscripciones.Models;
using Inscripciones.Models.Commons;

namespace Inscripciones.ApiControllers.Horarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDetalleHorariosController : ControllerBase
    {
        private readonly InscripcionesContext _context;

        public ApiDetalleHorariosController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: api/ApiDetalleHorarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleHorario>>> GetDetalleHorario()
        {
            return await _context.detalleshorarios.ToListAsync();
        }

        // GET: api/ApiDetalleHorarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleHorario>> GetDetalleHorario(int id)
        {
            var detalleHorario = await _context.detalleshorarios.FindAsync(id);

            if (detalleHorario == null)
            {
                return NotFound();
            }

            return detalleHorario;
        }

        // PUT: api/ApiDetalleHorarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleHorario(int id, DetalleHorario detalleHorario)
        {
            if (id != detalleHorario.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleHorario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleHorarioExists(id))
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

        // POST: api/ApiDetalleHorarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleHorario>> PostDetalleHorario(DetalleHorario detalleHorario)
        {
            _context.detalleshorarios.Add(detalleHorario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleHorario", new { id = detalleHorario.Id }, detalleHorario);
        }

        // DELETE: api/ApiDetalleHorarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleHorario(int id)
        {
            var detalleHorario = await _context.detalleshorarios.FindAsync(id);
            if (detalleHorario == null)
            {
                return NotFound();
            }
            detalleHorario.Eliminado = true;
            _context.detalleshorarios.Update(detalleHorario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleHorarioExists(int id)
        {
            return _context.detalleshorarios.Any(e => e.Id == id);
        }
    }
}
