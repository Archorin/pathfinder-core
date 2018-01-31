using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PathfinderCore.Contexts;
using PathfinderCore.Models;

namespace PathfinderCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Alignements")]
    [EnableCors(policyName: "AllowSpecificOrigin")]
    public class AlignementsController : Controller
    {
        private readonly PathfinderContext _context;

        public AlignementsController(PathfinderContext context)
        {
            _context = context;
        }

        // GET: api/Alignements
        [HttpGet]
        public IEnumerable<Alignement> GetAlignement()
        {
            return _context
                .Alignement
                .Include("ClasseAlignements.Classe");
        }

        // GET: api/Alignements/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlignement([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alignement = await _context.Alignement.SingleOrDefaultAsync(m => m.Id == id);

            if (alignement == null)
            {
                return NotFound();
            }

            return Ok(alignement);
        }

        // PUT: api/Alignements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlignement([FromRoute] int id, [FromBody] Alignement alignement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alignement.Id)
            {
                return BadRequest();
            }

            _context.Entry(alignement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlignementExists(id))
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

        // POST: api/Alignements
        [HttpPost]
        public async Task<IActionResult> PostAlignement([FromBody] Alignement alignement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Alignement.Add(alignement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlignement", new { id = alignement.Id }, alignement);
        }

        // DELETE: api/Alignements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlignement([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alignement = await _context.Alignement.SingleOrDefaultAsync(m => m.Id == id);
            if (alignement == null)
            {
                return NotFound();
            }

            _context.Alignement.Remove(alignement);
            await _context.SaveChangesAsync();

            return Ok(alignement);
        }

        private bool AlignementExists(int id)
        {
            return _context.Alignement.Any(e => e.Id == id);
        }
    }
}