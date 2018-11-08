using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarMeetingManager.DAL;
using CarMeetingManager.Models;

namespace CarMeetingManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JapaneseController : ControllerBase
    {
        private readonly CarMeetingContext _context;

        public JapaneseController(CarMeetingContext context)
        {
            _context = context;
        }

        // GET: api/Japanese
        [HttpGet]
        public IEnumerable<Japanese> GetJapaneses()
        {
            return _context.Japaneses;
        }

        // GET: api/Japanese/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJapanese([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var japanese = await _context.Japaneses.FindAsync(id);

            if (japanese == null)
            {
                return NotFound();
            }

            return Ok(japanese);
        }

        // PUT: api/Japanese/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJapanese([FromRoute] int id, [FromBody] Japanese japanese)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != japanese.JapaneseId)
            {
                return BadRequest();
            }

            _context.Entry(japanese).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JapaneseExists(id))
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

        // POST: api/Japanese
        [HttpPost]
        public async Task<IActionResult> PostJapanese([FromBody] Japanese japanese)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Japaneses.Add(japanese);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJapanese", new { id = japanese.JapaneseId }, japanese);
        }

        // DELETE: api/Japanese/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJapanese([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var japanese = await _context.Japaneses.FindAsync(id);
            if (japanese == null)
            {
                return NotFound();
            }

            _context.Japaneses.Remove(japanese);
            await _context.SaveChangesAsync();

            return Ok(japanese);
        }

        private bool JapaneseExists(int id)
        {
            return _context.Japaneses.Any(e => e.JapaneseId == id);
        }
    }
}