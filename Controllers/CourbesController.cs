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
    [Route("api/Courbes")]
    public class CourbesController : Controller
    {
        private readonly PathfinderContext _context;

        public CourbesController(PathfinderContext context)
        {
            _context = context;
        }

        // GET: api/Courbes
        [HttpGet]
        public IEnumerable<Courbe> GetCourbe()
        {
            return _context
                .Courbe
                .Include(c => c.Statistiques);
        }

        // GET: api/Courbes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourbe([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courbe = await _context.Courbe
                .Include(c => c.Statistiques)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (courbe == null)
            {
                return NotFound();
            }

            return Ok(courbe);
        }

        // PUT: api/Courbes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourbe([FromRoute] int id, [FromBody] Courbe courbe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courbe.Id)
            {
                return BadRequest();
            }

            _context.Entry(courbe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourbeExists(id))
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

        // POST: api/Courbes
        [HttpPost]
        public async Task<IActionResult> PostCourbe([FromBody] Courbe courbe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Courbe.Add(courbe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourbe", new { id = courbe.Id }, courbe);
        }

        // DELETE: api/Courbes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourbe([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courbe = await _context.Courbe.SingleOrDefaultAsync(m => m.Id == id);
            if (courbe == null)
            {
                return NotFound();
            }

            _context.Courbe.Remove(courbe);
            await _context.SaveChangesAsync();

            return Ok(courbe);
        }

        private bool CourbeExists(int id)
        {
            return _context.Courbe.Any(e => e.Id == id);
        }
    }
}