using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PathfinderCore.Contexts;
using PathfinderCore.Models;

namespace PathfinderCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Classes")]
    public class ClassesController : Controller
    {
        private readonly PathfinderContext _context;

        public ClassesController(PathfinderContext context)
        {
            _context = context;
        }

        // GET: api/Classes
        [HttpGet]
        public IEnumerable<Classe> GetClasse()
        {
            return _context.Classe
                .Include(c => c.DV)
                .Include(c => c.BBA)
                    .ThenInclude(courbe => courbe.Statistiques)
                .Include(c => c.Ouvrage)
                .Include(c => c.Vigueur)
                    .ThenInclude(courbe => courbe.Statistiques)
                .Include(c => c.Volonte)
                    .ThenInclude(courbe => courbe.Statistiques)
                .Include(c => c.Reflexe)
                    .ThenInclude(courbe => courbe.Statistiques)
                .Include("ClasseAlignements.Alignement");
        }

        // GET: api/Classes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClasse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classe = await _context
                .Classe
                .Include(c => c.DV)
                .Include(c => c.BBA)
                    .ThenInclude(courbe => courbe.Statistiques)
                .Include(c => c.Ouvrage)
                .Include(c => c.Vigueur)
                    .ThenInclude(courbe => courbe.Statistiques)
                .Include(c => c.Volonte)
                    .ThenInclude(courbe => courbe.Statistiques)
                .Include(c => c.Reflexe)
                    .ThenInclude(courbe => courbe.Statistiques)
                .Include("ClasseAlignements.Alignement")
                .SingleOrDefaultAsync(m => m.Id == id);

            if (classe == null)
            {
                return NotFound();
            }

            return Ok(classe);
        }

        // PUT: api/Classes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasse([FromRoute] int id, [FromBody] Classe classe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classe.Id)
            {
                return BadRequest();
            }

            _context.Entry(classe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasseExists(id))
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

        // POST: api/Classes
        [HttpPost]
        public async Task<IActionResult> PostClasse([FromBody] Classe classe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Classe.Add(classe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClasse", new { id = classe.Id }, classe);
        }

        // DELETE: api/Classes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClasse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classe = await _context.Classe.SingleOrDefaultAsync(m => m.Id == id);
            if (classe == null)
            {
                return NotFound();
            }

            _context.Classe.Remove(classe);
            await _context.SaveChangesAsync();

            return Ok(classe);
        }

        private bool ClasseExists(int id)
        {
            return _context.Classe.Any(e => e.Id == id);
        }
    }
}