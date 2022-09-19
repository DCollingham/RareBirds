using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RareBirdsApi.Data.Birds;
using RareBirdsApi.Enums;
using RareBirdsApi.Models;

namespace RareBirdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        private readonly RareBirdsDbContext _context;
        private readonly IMapper _mapper;

        public BirdsController(RareBirdsDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Birds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetBirdsDTO>>> GetBirds()
        {
          if (_context.Birds == null)
          {
              return NotFound();
          }
           var birds = await _context.Birds.ToListAsync();
           return _mapper.Map<List<GetBirdsDTO>>(birds);
        }

        // GET: api/Birds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetBirdDTO>> GetBird(int id)
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
            var BirdDTO = _mapper.Map<GetBirdDTO>(bird);
            return BirdDTO;
        }

        // GET: api/Birds/rarity/red
        [HttpGet("rarity/{rarity}")]
        public async Task<ActionResult<IEnumerable<Bird>>> GetBirdByGenus(Rarity rarity)
        {
            
            if (_context.Birds == null)
            {
                return NotFound();
            }
            var birds = await _context.Birds
                .Where(q => q.Rarity == rarity)
                .ToListAsync();
            return birds;       
        }

        // PUT: api/Birds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBird(int id, PutBirdDTO birdDTO)
        {
            if (id != birdDTO.Id)
            {
                return BadRequest();
            }

            var bird = _mapper.Map<Bird>(birdDTO);
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
        [HttpPost]
        public async Task<ActionResult<PostBirdDTO>> PostBird(PostBirdDTO birdDTO)
        {
          if (_context.Birds == null)
          {
              return Problem("Entity set 'RareBirdsDbContext.Birds'  is null.");
          }
            var bird = _mapper.Map<Bird>(birdDTO);
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
