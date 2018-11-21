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
    public class EventTypesController : ControllerBase
    {
        private readonly CarMeetingContext _context;

        public EventTypesController(CarMeetingContext context)
        {
            _context = context;
        }

        // GET: api/EventTypes
        /*
        [HttpGet]
        public IEnumerable<EventType> GetEventTypes()
        {
            return _context.EventTypes;
        }

        // GET: api/EventTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventType = await _context.EventTypes.FindAsync(id);

            if (eventType == null)
            {
                return NotFound();
            }

            return Ok(eventType);
        }

        // PUT: api/EventTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventType([FromRoute] int id, [FromBody] EventType eventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventType.EventTypeId)
            {
                return BadRequest();
            }

            _context.Entry(eventType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTypeExists(id))
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

        // POST: api/EventTypes
        [HttpPost]
        public async Task<IActionResult> PostEventType([FromBody] EventType eventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EventTypes.Add(eventType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventType", new { id = eventType.EventTypeId }, eventType);
        }

        // DELETE: api/EventTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventType = await _context.EventTypes.FindAsync(id);
            if (eventType == null)
            {
                return NotFound();
            }

            _context.EventTypes.Remove(eventType);
            await _context.SaveChangesAsync();

            return Ok(eventType);
        }

        private bool EventTypeExists(int id)
        {
            return _context.EventTypes.Any(e => e.EventTypeId == id);
        }*/
    }
}