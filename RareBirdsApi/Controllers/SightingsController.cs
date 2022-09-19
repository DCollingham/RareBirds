using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RareBirdsApi.Data.Birds;
using RareBirdsApi.Data.Sightings;
using RareBirdsApi.Models;

namespace RareBirdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SightingsController : ControllerBase
    {
        private readonly RareBirdsDbContext _context;
        private readonly IMapper _mapper;

        public SightingsController(RareBirdsDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Sightings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetSightingDTO>>> GetSightings()
        {
            var sightings = await _context.Sightings.ToListAsync();
            var sightingDTO = _mapper.Map<List<GetSightingDTO>>(sightings);
            return Ok(sightingDTO); 
        }


        // GET: api/Birds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetBirdDetailsDTO>> GetBird(int id)
        {
            if (_context.Birds == null)
            {
                return NotFound();
            }
            var bird = await _context.Birds.Include(q => q.Sightings)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (bird == null)
            {
                return NotFound();
            }
            var BirdDTO = _mapper.Map<GetBirdDetailsDTO>(bird);
            return BirdDTO;
        }

        // PUT: api/Sightings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSighting(int id, PutSightingDTO sightingDTO)
        {
            if (id != sightingDTO.Id)
            {
                return BadRequest();
            }
            var sighting = _mapper.Map<Sighting>(sightingDTO);
            _context.Entry(sighting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SightingExists(id))
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

        // POST: api/Sightings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sighting>> PostSighting(PostSightingDTO sightingDTO)
        {
            var sighting = _mapper.Map<Sighting>(sightingDTO);
            _context.Sightings.Add(sighting);
            await _context.SaveChangesAsync();
            return CreatedAtAction("PostSighting", new { id = sighting.Id }, sighting);
        }

        // DELETE: api/Sightings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSighting(int id)
        {
            var sighting = await _context.Sightings.FindAsync(id);
            if (sighting == null)
            {
                return NotFound();
            }
            _context.Sightings.Remove(sighting);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool SightingExists(int id)
        {
            return _context.Sightings.Any(e => e.Id == id);
        }
    }
}
