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
    [Route("api/Dons")]
    public class DonsController : Controller
    {
        private readonly PathfinderContext _context;

        public DonsController(PathfinderContext context)
        {
            _context = context;
        }

        // GET: api/Dons
        [HttpGet]
        public IEnumerable<Don> GetDon()
        {
            return _context.Don;
        }

        // GET: api/Dons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var don = await _context.Don.SingleOrDefaultAsync(m => m.Id == id);

            if (don == null)
            {
                return NotFound();
            }

            return Ok(don);
        }

        // PUT: api/Dons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDon([FromRoute] int id, [FromBody] Don don)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != don.Id)
            {
                return BadRequest();
            }

            _context.Entry(don).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonExists(id))
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

        // POST: api/Dons
        [HttpPost]
        public async Task<IActionResult> PostDon([FromBody] Don don)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Don.Add(don);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDon", new { id = don.Id }, don);
        }

        // DELETE: api/Dons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var don = await _context.Don.SingleOrDefaultAsync(m => m.Id == id);
            if (don == null)
            {
                return NotFound();
            }

            _context.Don.Remove(don);
            await _context.SaveChangesAsync();

            return Ok(don);
        }

        private bool DonExists(int id)
        {
            return _context.Don.Any(e => e.Id == id);
        }
    }
}