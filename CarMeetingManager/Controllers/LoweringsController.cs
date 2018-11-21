using CarMeetingManager.DAL;
using CarMeetingManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoweringsController : ControllerBase
    {
        private readonly CarMeetingContext _context;

        public LoweringsController(CarMeetingContext context)
        {
            _context = context;
        }
        /*
        // GET: api/Lowerings
        [HttpGet]
        public IEnumerable<Lowering> GetLowerings()
        {
            return _context.Lowerings;
        }

        // GET: api/Lowerings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLowering([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lowering = await _context.Lowerings.FindAsync(id);

            if (lowering == null)
            {
                return NotFound();
            }

            return Ok(lowering);
        }

        // PUT: api/Lowerings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLowering([FromRoute] int id, [FromBody] Lowering lowering)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lowering.LoweringId)
            {
                return BadRequest();
            }

            _context.Entry(lowering).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoweringExists(id))
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

        // POST: api/Lowerings
        [HttpPost]
        public async Task<IActionResult> PostLowering([FromBody] LoweringType lowering)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Lowerings.Add(lowering);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLowering", new { id = lowering.LoweringId }, lowering);
        }

        // DELETE: api/Lowerings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLowering([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lowering = await _context.Lowerings.FindAsync(id);
            if (lowering == null)
            {
                return NotFound();
            }

            _context.Lowerings.Remove(lowering);
            await _context.SaveChangesAsync();

            return Ok(lowering);
        }

        private bool LoweringExists(int id)
        {
            return _context.Lowerings.Any(e => e.LoweringId == id);
        }*/
    }
}