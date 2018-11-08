using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarMeetingManager.DAL;
using CarTuningEventManager.Models;

namespace CarMeetingManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GermanController : ControllerBase
    {
        private readonly CarMeetingContext _context;

        public GermanController(CarMeetingContext context)
        {
            _context = context;

            if (_context.Germans.Count() == 0)
            {
                var german = new List<German>
            {
                new German { Make="BMW" },
                new German { Make="Audi" },
                new German { Make="Mercedes" },
                new German { Make="Porsche" },
                new German { Make="Volkswagen"},
                new German { Make="Opel"}
            };
                german.ForEach(g => context.Germans.Add(g));
                context.SaveChanges();
            }
        }

        // GET: api/German
        [HttpGet]
        public IEnumerable<German> GetGermans()
        {
            return _context.Germans;
        }

        // GET: api/German/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGerman([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var german = await _context.Germans.FindAsync(id);

            if (german == null)
            {
                return NotFound();
            }

            return Ok(german);
        }

        // PUT: api/German/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGerman([FromRoute] int id, [FromBody] German german)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != german.GermanId)
            {
                return BadRequest();
            }

            _context.Entry(german).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GermanExists(id))
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

        // POST: api/German
        [HttpPost]
        public async Task<IActionResult> PostGerman([FromBody] German german)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Germans.Add(german);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGerman", new { id = german.GermanId }, german);
        }

        // DELETE: api/German/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGerman([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var german = await _context.Germans.FindAsync(id);
            if (german == null)
            {
                return NotFound();
            }

            _context.Germans.Remove(german);
            await _context.SaveChangesAsync();

            return Ok(german);
        }

        private bool GermanExists(int id)
        {
            return _context.Germans.Any(e => e.GermanId == id);
        }
    }
}