using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models.Commons;
using Inscripciones.Models;

namespace Inscripciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiMateriasController : ControllerBase
    {
        private readonly InscripcionesContext _context;

        public ApiMateriasController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: api/ApiMaterias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materia>>> GetMaterias()
        {
            return await _context.materias.ToListAsync();
        }

        // GET: api/ApiMaterias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> GetMaterias(int id)
        {
            var materias = await _context.materias.FindAsync(id);

            if (materias == null)
            {
                return NotFound();
            }

            return materias;
        }

        // PUT: api/ApiMaterias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterias(int id, Materia materias)
        {
            if (id != materias.Id)
            {
                return BadRequest();
            }

            _context.Entry(materias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriasExists(id))
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

        // POST: api/ApiMaterias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Materia>> PostMaterias(Materia materias)
        {
            _context.materias.Add(materias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterias", new { id = materias.Id }, materias);
        }

        // DELETE: api/ApiMaterias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterias(int id)
        {
            var materias = await _context.materias.FindAsync(id);
            if (materias == null)
            {
                return NotFound();
            }
            materias.Eliminado = true;
            _context.materias.Update(materias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MateriasExists(int id)
        {
            return _context.materias.Any(e => e.Id == id);
        }
    }
}
