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
    [Route("api/Specials")]
    public class SpecialsController : Controller
    {
        private readonly PathfinderContext _context;

        public SpecialsController(PathfinderContext context)
        {
            _context = context;
        }

        // GET: api/Specials
        [HttpGet]
        public IEnumerable<Special> GetSpecial()
        {
            return _context.Special;
        }

        // GET: api/Specials/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var special = await _context.Special.SingleOrDefaultAsync(m => m.Id == id);

            if (special == null)
            {
                return NotFound();
            }

            return Ok(special);
        }

        // PUT: api/Specials/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecial([FromRoute] int id, [FromBody] Special special)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != special.Id)
            {
                return BadRequest();
            }

            _context.Entry(special).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialExists(id))
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

        // POST: api/Specials
        [HttpPost]
        public async Task<IActionResult> PostSpecial([FromBody] Special special)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Special.Add(special);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecial", new { id = special.Id }, special);
        }

        // DELETE: api/Specials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var special = await _context.Special.SingleOrDefaultAsync(m => m.Id == id);
            if (special == null)
            {
                return NotFound();
            }

            _context.Special.Remove(special);
            await _context.SaveChangesAsync();

            return Ok(special);
        }

        private bool SpecialExists(int id)
        {
            return _context.Special.Any(e => e.Id == id);
        }
    }
}