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
    [Route("api/Caracteristiques")]
    public class CaracteristiquesController : Controller
    {
        private readonly PathfinderContext _context;

        public CaracteristiquesController(PathfinderContext context)
        {
            _context = context;
        }

        // GET: api/Caracteristiques
        [HttpGet]
        public IEnumerable<Caracteristique> GetCaracteristique()
        {
            return _context.Caracteristique;
        }

        // GET: api/Caracteristiques/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCaracteristique([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var caracteristique = await _context.Caracteristique.SingleOrDefaultAsync(m => m.Id == id);

            if (caracteristique == null)
            {
                return NotFound();
            }

            return Ok(caracteristique);
        }

        // PUT: api/Caracteristiques/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaracteristique([FromRoute] string id, [FromBody] Caracteristique caracteristique)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caracteristique.Id)
            {
                return BadRequest();
            }

            _context.Entry(caracteristique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaracteristiqueExists(id))
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

        // POST: api/Caracteristiques
        [HttpPost]
        public async Task<IActionResult> PostCaracteristique([FromBody] Caracteristique caracteristique)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Caracteristique.Add(caracteristique);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaracteristique", new { id = caracteristique.Id }, caracteristique);
        }

        // DELETE: api/Caracteristiques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaracteristique([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var caracteristique = await _context.Caracteristique.SingleOrDefaultAsync(m => m.Id == id);
            if (caracteristique == null)
            {
                return NotFound();
            }

            _context.Caracteristique.Remove(caracteristique);
            await _context.SaveChangesAsync();

            return Ok(caracteristique);
        }

        private bool CaracteristiqueExists(string id)
        {
            return _context.Caracteristique.Any(e => e.Id == id);
        }
    }
}