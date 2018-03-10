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
    [Route("api/Ouvrages")]
    public class OuvragesController : Controller
    {
        private readonly PathfinderContext _context;

        public OuvragesController(PathfinderContext context)
        {
            _context = context;
        }

        // GET: api/Ouvrages
        [HttpGet]
        public IEnumerable<Ouvrage> GetOuvrage()
        {
            return _context.Ouvrage;
        }

        // GET: api/Ouvrages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOuvrage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ouvrage = await _context.Ouvrage.SingleOrDefaultAsync(m => m.Id == id);

            if (ouvrage == null)
            {
                return NotFound();
            }

            return Ok(ouvrage);
        }

        // PUT: api/Ouvrages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOuvrage([FromRoute] int id, [FromBody] Ouvrage ouvrage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ouvrage.Id)
            {
                return BadRequest();
            }

            _context.Entry(ouvrage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OuvrageExists(id))
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

        // POST: api/Ouvrages
        [HttpPost]
        public async Task<IActionResult> PostOuvrage([FromBody] Ouvrage ouvrage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Ouvrage.Add(ouvrage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOuvrage", new { id = ouvrage.Id }, ouvrage);
        }

        // DELETE: api/Ouvrages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOuvrage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ouvrage = await _context.Ouvrage.SingleOrDefaultAsync(m => m.Id == id);
            if (ouvrage == null)
            {
                return NotFound();
            }

            _context.Ouvrage.Remove(ouvrage);
            await _context.SaveChangesAsync();

            return Ok(ouvrage);
        }

        private bool OuvrageExists(int id)
        {
            return _context.Ouvrage.Any(e => e.Id == id);
        }
    }
}