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
    [Route("api/ClasseAlignements")]
    public class ClasseAlignementsController : Controller
    {
        private readonly PathfinderContext _context;

        public ClasseAlignementsController(PathfinderContext context)
        {
            _context = context;
        }

        // GET: api/ClasseAlignements
        [HttpGet]
        public IEnumerable<ClasseAlignement> GetClasseAlignement()
        {
            return _context
                .ClasseAlignement
                .Include(ca => ca.Classe)
                .Include(ca => ca.Alignement);
        }

        // GET: api/ClasseAlignements/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClasseAlignement([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classeAlignement = await _context.ClasseAlignement.SingleOrDefaultAsync(m => m.ClasseId == id);

            if (classeAlignement == null)
            {
                return NotFound();
            }

            return Ok(classeAlignement);
        }

        // PUT: api/ClasseAlignements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasseAlignement([FromRoute] int id, [FromBody] ClasseAlignement classeAlignement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classeAlignement.ClasseId)
            {
                return BadRequest();
            }

            _context.Entry(classeAlignement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasseAlignementExists(id))
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

        // POST: api/ClasseAlignements
        [HttpPost]
        public async Task<IActionResult> PostClasseAlignement([FromBody] ClasseAlignement classeAlignement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ClasseAlignement.Add(classeAlignement);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClasseAlignementExists(classeAlignement.ClasseId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClasseAlignement", new { id = classeAlignement.ClasseId }, classeAlignement);
        }

        // DELETE: api/ClasseAlignements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClasseAlignement([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classeAlignement = await _context.ClasseAlignement.SingleOrDefaultAsync(m => m.ClasseId == id);
            if (classeAlignement == null)
            {
                return NotFound();
            }

            _context.ClasseAlignement.Remove(classeAlignement);
            await _context.SaveChangesAsync();

            return Ok(classeAlignement);
        }

        private bool ClasseAlignementExists(int id)
        {
            return _context.ClasseAlignement.Any(e => e.ClasseId == id);
        }
    }
}