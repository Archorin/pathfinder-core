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
    [Route("api/Statistiques")]
    public class StatistiquesController : Controller
    {
        private readonly PathfinderContext _context;

        public StatistiquesController(PathfinderContext context)
        {
            _context = context;
        }

        // GET: api/Statistiques
        [HttpGet]
        public IEnumerable<Statistique> GetStatistique()
        {
            return _context
                .Statistique
                .Include(s => s.Courbe);
        }

        // GET: api/Statistiques/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatistique([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var statistique = await _context.Statistique.SingleOrDefaultAsync(m => m.Id == id);

            if (statistique == null)
            {
                return NotFound();
            }

            return Ok(statistique);
        }

        // PUT: api/Statistiques/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatistique([FromRoute] int id, [FromBody] Statistique statistique)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statistique.Id)
            {
                return BadRequest();
            }

            _context.Entry(statistique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatistiqueExists(id))
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

        // POST: api/Statistiques
        [HttpPost]
        public async Task<IActionResult> PostStatistique([FromBody] Statistique statistique)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Statistique.Add(statistique);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatistique", new { id = statistique.Id }, statistique);
        }

        // DELETE: api/Statistiques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatistique([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var statistique = await _context.Statistique.SingleOrDefaultAsync(m => m.Id == id);
            if (statistique == null)
            {
                return NotFound();
            }

            _context.Statistique.Remove(statistique);
            await _context.SaveChangesAsync();

            return Ok(statistique);
        }

        private bool StatistiqueExists(int id)
        {
            return _context.Statistique.Any(e => e.Id == id);
        }
    }
}