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
using Microsoft.AspNetCore.Authorization;

namespace PathfinderCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Personnages")]
    [EnableCors(policyName: "AllowSpecificOrigin")]
    public class PersonnagesController : Controller
    {
        private readonly PathfinderContext _context;

        public PersonnagesController(PathfinderContext context)
        {
            _context = context;
        }

        // GET: api/Personnages
        [HttpGet, Authorize]
        public IEnumerable<Personnage> GetPersonnage()
        {
            return _context.Personnage;
        }

        // GET: api/Personnages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonnage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personnage = await _context.Personnage.SingleOrDefaultAsync(m => m.Id == id);

            if (personnage == null)
            {
                return NotFound();
            }

            return Ok(personnage);
        }

        // PUT: api/Personnages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonnage([FromRoute] int id, [FromBody] Personnage personnage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personnage.Id)
            {
                return BadRequest();
            }

            _context.Entry(personnage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonnageExists(id))
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

        // POST: api/Personnages
        [HttpPost]
        public async Task<IActionResult> PostPersonnage([FromBody] Personnage personnage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Personnage.Add(personnage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonnage", new { id = personnage.Id }, personnage);
        }

        // DELETE: api/Personnages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonnage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personnage = await _context.Personnage.SingleOrDefaultAsync(m => m.Id == id);
            if (personnage == null)
            {
                return NotFound();
            }

            _context.Personnage.Remove(personnage);
            await _context.SaveChangesAsync();

            return Ok(personnage);
        }

        private bool PersonnageExists(int id)
        {
            return _context.Personnage.Any(e => e.Id == id);
        }
    }
}