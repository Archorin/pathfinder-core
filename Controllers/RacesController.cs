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
    [Route("api/Races")]
    public class RacesController : Controller
    {
        private readonly PathfinderContext _context;

        public RacesController(PathfinderContext context)
        {
            _context = context;
        }

        // GET: api/Races
        [HttpGet]
        public IEnumerable<Race> GetRace()
        {
            return _context.Race;
        }

        // GET: api/Races/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRace([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var race = await _context.Race.SingleOrDefaultAsync(m => m.Id == id);

            if (race == null)
            {
                return NotFound();
            }

            return Ok(race);
        }

        // PUT: api/Races/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRace([FromRoute] int id, [FromBody] Race race)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != race.Id)
            {
                return BadRequest();
            }

            _context.Entry(race).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceExists(id))
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

        // POST: api/Races
        [HttpPost]
        public async Task<IActionResult> PostRace([FromBody] Race race)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Race.Add(race);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRace", new { id = race.Id }, race);
        }

        // DELETE: api/Races/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRace([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var race = await _context.Race.SingleOrDefaultAsync(m => m.Id == id);
            if (race == null)
            {
                return NotFound();
            }

            _context.Race.Remove(race);
            await _context.SaveChangesAsync();

            return Ok(race);
        }

        private bool RaceExists(int id)
        {
            return _context.Race.Any(e => e.Id == id);
        }
    }
}