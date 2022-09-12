using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RareBirdsApi.Models;

namespace RareBirdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        private readonly RareBirdsDbContext _context;

        public BirdsController(RareBirdsDbContext context)
        {
            _context = context;
        }

        // GET: api/Birds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bird>>> GetBirds()
        {
          if (_context.Birds == null)
          {
              return NotFound();
          }
            return await _context.Birds.ToListAsync();
        }

        // GET: api/Birds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bird>> GetBird(int id)
        {
          if (_context.Birds == null)
          {
              return NotFound();
          }
            var bird = await _context.Birds.FindAsync(id);

            if (bird == null)
            {
                return NotFound();
            }
            return bird;
        }

        // GET: api/Birds/genus/Perdix
        [HttpGet("genus/{genus}")]
        public async Task<ActionResult<IEnumerable<Bird>>> GetBirdByGenus(string genus)
        {
            
            if (_context.Birds == null)
            {
                return NotFound();
            }
            var birds = await _context.Birds
                .Where(q => q.Genus.Contains(genus))
                .ToListAsync();
            return birds;       
        }

        // PUT: api/Birds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBird(int id, Bird bird)
        {
            if (id != bird.Id)
            {
                return BadRequest();
            }

            _context.Entry(bird).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BirdExists(id))
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

        // POST: api/Birds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bird>> PostBird(Bird bird)
        {
          if (_context.Birds == null)
          {
              return Problem("Entity set 'RareBirdsDbContext.Birds'  is null.");
          }
            _context.Birds.Add(bird);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBird", new { id = bird.Id }, bird);
        }

        // DELETE: api/Birds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBird(int id)
        {
            if (_context.Birds == null)
            {
                return NotFound();
            }
            var bird = await _context.Birds.FindAsync(id);
            if (bird == null)
            {
                return NotFound();
            }

            _context.Birds.Remove(bird);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BirdExists(int id)
        {
            return (_context.Birds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
