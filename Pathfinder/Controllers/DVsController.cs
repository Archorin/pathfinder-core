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
    [Route("api/DVs")]
    public class DVsController : Controller
    {
        private readonly PathfinderContext _context;

        public DVsController(PathfinderContext context)
        {
            _context = context;
        }

        // GET: api/DVs
        [HttpGet]
        public IEnumerable<DV> GetDV()
        {
            return _context
                .DV
                .Include(dv => dv.Classes);
        }

        // GET: api/DVs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDV([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dV = await _context
                .DV
                .Include(dv => dv.Classes)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (dV == null)
            {
                return NotFound();
            }

            return Ok(dV);
        }

        // PUT: api/DVs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDV([FromRoute] int id, [FromBody] DV dV)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dV.Id)
            {
                return BadRequest();
            }

            _context.Entry(dV).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DVExists(id))
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

        // POST: api/DVs
        [HttpPost]
        public async Task<IActionResult> PostDV([FromBody] DV dV)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DV.Add(dV);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDV", new { id = dV.Id }, dV);
        }

        // DELETE: api/DVs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDV([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dV = await _context.DV.SingleOrDefaultAsync(m => m.Id == id);
            if (dV == null)
            {
                return NotFound();
            }

            _context.DV.Remove(dV);
            await _context.SaveChangesAsync();

            return Ok(dV);
        }

        private bool DVExists(int id)
        {
            return _context.DV.Any(e => e.Id == id);
        }
    }
}