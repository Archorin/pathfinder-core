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
    [Route("api/Competences")]
    public class CompetencesController : Controller
    {
        private readonly PathfinderContext _context;

        public CompetencesController(PathfinderContext context)
        {
            _context = context;
        }

        // GET: api/Competences
        [HttpGet]
        public IEnumerable<Competence> GetCompetence()
        {
            return _context.Competence;
        }

        // GET: api/Competences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompetence([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var competence = await _context.Competence.SingleOrDefaultAsync(m => m.Id == id);

            if (competence == null)
            {
                return NotFound();
            }

            return Ok(competence);
        }

        // PUT: api/Competences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetence([FromRoute] int id, [FromBody] Competence competence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != competence.Id)
            {
                return BadRequest();
            }

            _context.Entry(competence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetenceExists(id))
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

        // POST: api/Competences
        [HttpPost]
        public async Task<IActionResult> PostCompetence([FromBody] Competence competence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Competence.Add(competence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompetence", new { id = competence.Id }, competence);
        }

        // DELETE: api/Competences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetence([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var competence = await _context.Competence.SingleOrDefaultAsync(m => m.Id == id);
            if (competence == null)
            {
                return NotFound();
            }

            _context.Competence.Remove(competence);
            await _context.SaveChangesAsync();

            return Ok(competence);
        }

        private bool CompetenceExists(int id)
        {
            return _context.Competence.Any(e => e.Id == id);
        }
    }
}